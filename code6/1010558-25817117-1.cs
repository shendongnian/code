    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            private string input = @"
    0 VANGUARD 1
    1 00005U 58002B   14242.42781498  .00000028  00000-0  24556-4 0  2568
    2 00005 034.2497 271.4959 1848458 183.2227 175.4750 10.84383299975339
    0 TRANSIT 2A
    1 00045U 60007A   14245.43855606  .00000265  00000-0  95096-4 0  2208
    2 00045 066.6958 193.0879 0251338 053.7315 060.2264 14.33038972819563
    0 EXPLORER 11
    1 00107U 61013A   14245.36883128  .00001088  00000-0  12832-3 0  1217
    2 00107 028.7916 229.2883 0562255 219.9933 302.0575 14.05099145667434
    ";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var regexObj = new Regex(@"(?<=^\d+\s(?<name>[\w|\d|\s]+))\r\n(?<line1>(?<=^).*)\r\n(?<line2>(?<=^).*)",
                    RegexOptions.Multiline);
                Match matchResult = regexObj.Match(input);
                while (matchResult.Success)
                {
                    Console.WriteLine("Name: " + matchResult.Groups["name"].Value);
                    Console.WriteLine("Line 1: " + matchResult.Groups["line1"].Value);
                    Console.WriteLine("Line 2: " + matchResult.Groups["line2"].Value);
                    matchResult = matchResult.NextMatch();
                }
            }
        }
    }
