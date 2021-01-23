        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                SendKeys.SendWait("D:\\testing.txt"); // enter the file path, which suppose to upload.
                SendKeys.SendWait("{TAB 2}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
