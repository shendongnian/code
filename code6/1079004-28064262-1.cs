        using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    
    namespace TestingDevExpress
    {
        public partial class Form01 : DevExpress.XtraEditors.XtraForm
        {
            public Form01()
            {
                InitializeComponent();
    
            }
    
            private void SetProperties()
            {
    
                label1.Text = "Date of Birth:";
    
                label1.Parent = pictureBox1;
    
                button1.Parent = pictureBox1;
    
            }
    
            private void Submit(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex.Equals(0) || comboBox2.SelectedIndex.Equals(0) || comboBox3.SelectedIndex.Equals(0))
                {
                        
                    MessageBox.Show("Date, Month, and Year required, please fill them!", "Information");
                }
    
                else
                {
                    int visitorAge = comboBox3.SelectedIndex - DateTime.Now.Year;
    
                    MessageBox.Show(visitorAge + Convert.ToString(DateTime.Now));
                }
            }
    
            private void CheckPossibleCalendar(object sender, EventArgs e)
            {
                int day = DateTime.DaysInMonth(Convert.ToInt32(comboBox3.Text), comboBox2.SelectedIndex + 1);
    
                if (day <= comboBox1.SelectedIndex)
                {
                    MessageBox.Show("You have entered wrong Date, Month, or Year!", "Warning");
    
                    SetCalendarIndex();
                }
            }
    
            private void SetValues()
            {
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
    
                comboBox1.Items.Add("Date");
    
                comboBox2.Items.Add("Month");
    
                comboBox3.Items.Add("Year");
    
                for (int i = 1; i < 32; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
    
                for (int i = 1; i < 13; i++)
                {
                    comboBox2.Items.Add(info.GetMonthName(i));
                }
    
                for (int i = 1980; i < DateTime.Now.Year + 1; i++)
                {
                    comboBox3.Items.Add(i.ToString());
                }
    
                SetCalendarIndex();
            }
    
            private void SetCalendarIndex()
            {
                comboBox1.SelectedIndex = 0;
    
                comboBox2.SelectedIndex = 0;
    
                comboBox3.SelectedIndex = 0;
            }
    
            private void Form01_Load_1(object sender, EventArgs e)
            {
                SetProperties();
    
                SetValues();
            }
        }
    }
