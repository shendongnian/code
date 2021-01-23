     public partial class AgeConfirmation : Form
        {
            public AgeConfirmation()
            {
                InitializeComponent();
        
            }
        
            private void AgeConfirmation_Load(object sender, EventArgs e)
            {
                SystemManager.SetFullScreen(this);
        
                SetProperties();
        
                SetValues();
            }
        
            private void SetProperties()
            {
                pictureBox1.Size = new Size(SystemManager._workingRectangle.Width, SystemManager._workingRectangle.Height);
        
                label1.Text = "Date of Birth:";
        
                label1.Location = new Point((SystemManager._workingRectangle.Width / 2) - 75, (SystemManager._workingRectangle.Height / 2) - 100);
        
                label1.Parent = pictureBox1;
        
                comboBox1.Location = new Point((SystemManager._workingRectangle.Width / 2) - 175, (SystemManager._workingRectangle.Height / 2) - 50);
        
                comboBox2.Location = new Point((SystemManager._workingRectangle.Width / 2) - 50, (SystemManager._workingRectangle.Height / 2) - 50);
        
                comboBox3.Location = new Point((SystemManager._workingRectangle.Width / 2) + 75, (SystemManager._workingRectangle.Height / 2) - 50);
        
                button1.Parent = pictureBox1;
        
                button1.Location = new Point((SystemManager._workingRectangle.Width / 2) - 40, SystemManager._workingRectangle.Height / 2);
            }
        
            private void Submit(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex.Equals(0) || comboBox2.SelectedIndex.Equals(0) || comboBox3.SelectedIndex.Equals(0))
                {
                    SystemManager.ShowMessageBox("Date, Month, and Year required, please fill them!", "Information", 1);
                }
        
                else
                {
                    int visitorAge = comboBox3.SelectedIndex - DateTime.Now.Year;
        
                    SystemManager.AddAge(visitorAge, Convert.ToString(DateTime.Now));
                }
            }
        
            private void CheckPossibleCalendar(object sender, EventArgs e)
            {
                int day = DateTime.DaysInMonth(Convert.ToInt32(comboBox3.Text), comboBox2.SelectedIndex + 1);
        
                if (day <= comboBox1.SelectedIndex)
                {
                    SystemManager.ShowMessageBox("You have entered wrong Date, Month, or Year!", "Warning", 2);
        
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
        }
