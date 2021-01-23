        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            SendKeys.SendWait("^c");
            if (Clipboard.ContainsText())
            {
                label1.Text = Clipboard.GetText();
            }
        }
