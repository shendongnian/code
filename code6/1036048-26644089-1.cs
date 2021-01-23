        private void SetButtonEnableState()
        {
            int n;
            
            button1.Enabled = int.TryParse(textBox1.Text, out n) && int.TryParse(textBox2.Text, out n);
        }
