    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          Dictionary<int, string[]> comboBox1Options = new Dictionary<int, string[]>();
          comboBox1Options.Add(0, new[] { "1", "2", "3", "4" });
    
          comboBox1.Items.Clear();
          comboBox1.Items.AddRange(comboBox1Options[0]);
    
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          Dictionary<int, string[]> comboBox2Options = new Dictionary<int, string[]>();
          comboBox2Options.Add(0, new[] { "1", "2", "3", "4" });
          comboBox2Options.Add(1, new[] { "5", "6", "7", "8" });
          comboBox2Options.Add(2, new[] { "Corp Over 250k", "Corp Under 250k", "Hybrid Over 250k", "Hybrid Under 250k" });
    
          comboBox2.Items.Clear();
          comboBox2.Items.AddRange(comboBox2Options[comboBox1.SelectedIndex]);
          textBox2.Text = comboBox1.SelectedIndex.ToString();
        }
    
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          Dictionary<int, string[]> comboBox3Options = new Dictionary<int, string[]>();
          comboBox3Options.Add(0, new[] { "Move Amendment Override" });
          comboBox3Options.Add(1, new[] { "Move Ammendment Override INTERNAL" });
          comboBox3Options.Add(2, new[] { "250 - 399", "400 - 599", "600 - 799", "800 - 999" });
          comboBox3Options.Add(3, new[] { "Move Hybrid Documents" });
    
          comboBox3.Items.Clear();
          comboBox3.Items.AddRange(comboBox3Options[comboBox2.SelectedIndex]);
          textBox2.Text += comboBox2.SelectedIndex.ToString();
        }
    
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          textBox2.Text += comboBox3.SelectedIndex.ToString();
        }
      }
    }
