        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
               e.Cancel = false;
               return;
            }
            // other logic with Messagebox
            ...
        }
