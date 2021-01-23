    private bool IgnoreKeys = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.D1) && (!IgnoreKeys))
            {
                
                SendKeys.Send("Simulate this text" + "{ENTER}");
                
            }
            if (e.KeyData == Keys.F12)
            {
                IgnoreKeys = true;
                SendKeys.Send("123");
                SendKeys.Flush();
                IgnoreKeys = false;
            }
