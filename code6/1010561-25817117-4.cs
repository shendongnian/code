    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            private readonly BindingList<Satellite> _satellites = new BindingList<Satellite>();
            private string _input = @"
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
                var regexObj =
                    new Regex(@"(?<=^\d+\s(?<name>[\w|\d|\s]+))\r\n(?<line1>(?<=^).*)\r\n(?<line2>(?<=^).*(?=\r))",
                        RegexOptions.Multiline);
                Match matchResult = regexObj.Match(_input);
    
                while (matchResult.Success)
                {
                    string name = matchResult.Groups["name"].Value;
                    string line1 = matchResult.Groups["line1"].Value;
                    string line2 = matchResult.Groups["line2"].Value;
    
    
                    var regexObj1 = new Regex(@"(?<=^[1|2].*)([\d\w.-]+)");
                    Match matchResult1 = regexObj1.Match(line1);
                    var numbers1 = new List<string>();
                    while (matchResult1.Success)
                    {
                        string s = matchResult1.Value;
                        numbers1.Add(s);
                        matchResult1 = matchResult1.NextMatch();
                    }
    
                    var regexObj2 = new Regex(@"(?<=^[1|2].*)([\d\w.-]+)");
                    Match matchResult2 = regexObj2.Match(line2);
                    var numbers2 = new List<string>();
                    while (matchResult2.Success)
                    {
                        string s = matchResult2.Value;
                        numbers2.Add(s);
                        matchResult2 = matchResult2.NextMatch();
                    }
    
                    _satellites.Add(new Satellite
                    {
                        Name = name,
                        Line1 = line1,
                        Line2 = line2,
                        Numbers1 = numbers1,
                        Numbers2 = numbers2
                    });
    
    
                    matchResult = matchResult.NextMatch();
                }
    
                comboBox1.DataSource = _satellites;
                comboBox1.DisplayMember = "Name";
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                var comboBox = (ComboBox) sender;
                var satellites = comboBox.DataSource as List<Satellite>;
                if (satellites != null && comboBox.SelectedIndex > -1)
                {
                    Satellite selectedSatellite = satellites[comboBox.SelectedIndex];
                    Console.WriteLine("Selected satellite: " + selectedSatellite.Name);
                }
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                var textBox = (TextBox) sender;
                string text = textBox.Text;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    Satellite satellite =
                        _satellites.FirstOrDefault((s => s.Name.ToLower().StartsWith(text.ToLower())));
                    if (satellite != null)
                    {
                        Console.WriteLine("Found satellite: " + satellite);
                    }
                }
            }
    
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                var textBox = (TextBox) sender;
                string text = textBox.Text;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    Satellite satellite =
                        _satellites.FirstOrDefault(
                            s => s.Numbers1.Any(t => t.StartsWith(text)) || s.Numbers2.Any(t => t.StartsWith(text)));
                    if (satellite != null)
                    {
                        Console.WriteLine("Found satellite: " + satellite);
                    }
                }
            }
        }
    
        internal class Satellite
        {
            public string Name { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public List<string> Numbers1 { get; set; }
            public List<string> Numbers2 { get; set; }
    
            public override string ToString()
            {
                return string.Format("Name: {0}", Name);
            }
        }
    }
