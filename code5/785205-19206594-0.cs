    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler(ClickedButton);
            button2.Click += new System.EventHandler(ClickedButton);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        
        string orignalText = null; //you should define this var outside of ClickedButton method to keep its value during button1/2 clicks
        
        public void ClickedButton(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                orignalText = textBox1.Text;
                string replaced = Regex.Replace(orignalText, @"[A-Z]", "*");
                textBox1.Text = replaced;
            }
            else if (sender == button2)
            {
                if (orignalText != null) textBox1.Text = orignalText;
            }
        }
      }
    }
