        string orignalText;
        public void ClickedButton(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                orignalText = textBox1.Text;
                string replaced = Regex.Replace(orignalText, @"[A-Z]", "*");
                textBox1.Text = replaced;
            }
            else if (sender == button2)
            {
                textBox1.Text = orignalText;
            }
        }
