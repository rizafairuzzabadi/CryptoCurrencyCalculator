using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ganss.Excel;




namespace CryptoCurrencyCalculator_Bosch4
{

    public partial class CryptoCalculator : Form
    {
        private double DollarWal;
        private double BTCWal;
        private double BCHWal;
        private double LTCWal;
        private double XRPWal;
        private double ETHWal;
        private double SecondWal;

        private double BTCcoeff;
        private double BCHcoeff;
        private double LTCcoeff;
        private double XRPcoeff;
        private double ETHcoeff;

        private double YourBTC;
        private double YourBCH;
        private double YourLTC;
        private double YourXRP;
        private double YourETH;

        private List<double> arrayer = new List<double>();

        public CryptoCalculator()
        {
            InitializeComponent();
        }

        public record Crypto(
            string name,
            double Price
        );

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Opener_Click(object sender, EventArgs e)
        {
            string file = @"D:\Crypto.xlsx";
            var crypto = new ExcelMapper(file).Fetch<Crypto>();
            foreach (var st in crypto)
            {
                arrayer.Add(st.Price);
            }
            BTCcoeff = arrayer[0];
            BCHcoeff = arrayer[1];
            LTCcoeff = arrayer[2];
            XRPcoeff = arrayer[3];
            ETHcoeff = arrayer[4];
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            DollarWal = double.Parse(DollarValue.Text);
            BTCWal = DollarWal * 1 / BTCcoeff;
            BCHWal = DollarWal * 1 / BCHcoeff;
            LTCWal = DollarWal * 1 / LTCcoeff;
            XRPWal = DollarWal * 1 / XRPcoeff;
            ETHWal = DollarWal * 1 / ETHcoeff;

            btcval.Text = BTCWal.ToString();
            bchval.Text = BCHWal.ToString();
            ltcval.Text = LTCWal.ToString();
            xrpval.Text = XRPWal.ToString();
            ethval.Text = ETHWal.ToString();
        }

        private void BuyBTC_Click(object sender, EventArgs e)
        {
            if(YourBTC == 0)
            {
                YourBTC = BTCWal;
            }
            else
            {
                YourBTC = YourBTC + BTCWal;
            }
            btcval2.Text = YourBTC.ToString();
        }

        private void BuyBCH_Click(object sender, EventArgs e)
        {
            if (YourBCH == 0)
            {
                YourBCH = BCHWal;
            }
            else
            {
                YourBCH = YourBCH + BTCWal;
            }
            bchval2.Text = YourBCH.ToString();
        }

        private void BuyLTC_Click(object sender, EventArgs e)
        {
            if (YourLTC == 0)
            {
                YourLTC = LTCWal;
            }
            else
            {
                YourLTC = YourLTC + LTCWal;
            }
            ltcval2.Text = YourLTC.ToString();
        }

        private void BuyXRP_Click(object sender, EventArgs e)
        {
            if (YourXRP == 0)
            {
                YourXRP = XRPWal;
            }
            else
            {
                YourXRP = YourXRP + XRPWal;
            }
            xrpval2.Text = YourXRP.ToString();
        }

        private void BuyETH_Click(object sender, EventArgs e)
        {
            if (YourETH == 0)
            {
                YourETH = ETHWal;
            }
            else
            {
                YourETH = YourETH + ETHWal;
            }
            ethval2.Text = YourETH.ToString();
        }

        private void CalculateBTC_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            BTCWal = SecondWal * BTCcoeff;
            DollarValue.Text = BTCWal.ToString();
        }

        private void CalculateBCH_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            BCHWal = SecondWal * BCHcoeff;
            DollarValue.Text = BCHWal.ToString();
        }

        private void CalculateLTC_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            LTCWal = SecondWal * LTCcoeff;
            DollarValue.Text = LTCWal.ToString();
        }

        private void CalculateXRP_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            XRPWal = SecondWal * XRPcoeff;
            DollarValue.Text = XRPWal.ToString();
        }

        private void CalculateETH_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            ETHWal = SecondWal * ETHcoeff;
            DollarValue.Text = ETHWal.ToString();
        }

        private void sellbtc_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            BTCWal = SecondWal * BTCcoeff;
            DollarValue.Text = BTCWal.ToString();
            YourBTC -= SecondWal;
            btcval2.Text = YourBTC.ToString();
        }

        private void Sellbch_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            BCHWal = SecondWal * BCHcoeff;
            DollarValue.Text = BCHWal.ToString();
            YourBCH -= SecondWal;
            bchval2.Text = YourBCH.ToString();
        }

        private void sellltc_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            LTCWal = SecondWal * LTCcoeff;
            DollarValue.Text = LTCWal.ToString();
            YourLTC -= SecondWal;
            ltcval2.Text = YourLTC.ToString();
        }

        private void sellXRP_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            XRPWal = SecondWal * XRPcoeff;
            DollarValue.Text = XRPWal.ToString();
            YourXRP -= SecondWal;
            xrpval2.Text = YourXRP.ToString();
        }

        private void SellETH_Click(object sender, EventArgs e)
        {
            SecondWal = double.Parse(Inputer.Text);
            ETHWal = SecondWal * ETHcoeff;
            YourXRP -= SecondWal;
            ethval2.Text = YourETH.ToString();
            DollarValue.Text = ETHWal.ToString();
        }
    }
}
