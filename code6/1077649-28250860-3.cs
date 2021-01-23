    private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.TabStop = false;
            webBrowser1.Focus();
            webBrowser1.LostFocus += webBrowser1_LostFocus;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.TabStop = false;
            webBrowser1.Focus();
            webBrowser1.LostFocus += webBrowser1_LostFocus;
        }
