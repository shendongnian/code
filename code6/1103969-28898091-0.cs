    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.Items.Add("weekdays");
                comboBox1.Items.Add("year");
            }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedItem == "weekdays")
                {
                    comboBox2.Items.Add("Sunday");
                    comboBox2.Items.Add("Monday");
                    comboBox2.Items.Add("Tuesday");
                }
                else if (comboBox1.SelectedItem == "year")
                {
                    comboBox2.Items.Add("2012");
                    comboBox2.Items.Add("2013");
                    comboBox2.Items.Add("2014");
                }
            }
        }
    }
