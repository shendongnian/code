    public void Form1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to run the Event Register?","Registration Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                label5.Text = "Event Registration";
                textBox1.Select();
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                var fileSave = new FileStream(fullFileName, FileMode.Create);
                fileSave.Close();
                OfflineRegister();
    
            }
            else
            {
                label5.Text = "ICAS Register";
                textBox1.Select();
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                var fileSave = new FileStream(fullFileName, FileMode.Create);
                fileSave.Close();
                OnlineRegister();
    
            }
        }
    
        public void Online_Register(object sender, KeyPressEventArgs e)
        {
           OnlineRegister();
        }
    
        public void Offline_Register(object sender, KeyPressEventArgs e)
        {
           OfflineRegister();
        }
        
        public void OnlineRegister()
        {
         // Do Stuff
        }
        public void OfflineRegister()
        {
         // Do Stuff
        }
        
