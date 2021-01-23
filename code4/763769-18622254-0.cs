        private void button1_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Name = "testText";
            this.Controls.Add(tb);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)this.Controls.Find("testText",true)[0];
            tb.BackColor = System.Drawing.Color.Red; 
        }
