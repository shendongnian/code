        private void button1_Click(object sender, EventArgs e)
        {
            TextBox wc = new TextBox();
            
            this.Controls.Add(wc);
            wc.TextChanged+=wc_TextChanged;
        }
        void wc_TextChanged(object sender, EventArgs e)
        {
            //var box = (TextBox)sender;
            MessageBox.Show("TEXT CHANGED");
            
        }
