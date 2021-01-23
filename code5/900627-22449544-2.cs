        public static class Utility
        {
            public static string DisplayDateTime()
            {
                 return DateTime.Now.ToString();
            }
        }
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        timer1.Interval=1000;//one second
        timer1.Tick += new System.EventHandler(timer1_Tick);
        timer1.Start();
        
        private void timer1_Tick(object sender, EventArgs e)
        {
             //do whatever you want 
             Label1.Text = Utility.DisplayDateTime();
        }
