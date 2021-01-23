            public SubjectExamStart()
            {
                InitializeComponent();
    
                 examTime = TimeSpan.FromSeconds(double.Parse(conf[1]));
                        label1.Text = examTime.ToString();
                        timer1.Interval = 1000;
                        timer1.Start();
             }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (sender == timer1)
                {
                    if (examTime.TotalMinutes > 0)
                    {
                        examTime = examTime.Subtract(TimeSpan.FromSeconds(1));
                        label1.Text = examTime.ToString();
                    }
                    else
                    {
                        timer1.Stop();
                        MessageBox.Show("Exam Time is Finished");
                    }
                }
            }
