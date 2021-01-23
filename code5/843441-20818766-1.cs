     private string _mytext;
        public void SetText(string text)
        {
            _mytext = text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.SetText(textBox1.Text);
            f2.ShowDialog();
        }
        
