      private void Form1_Load(object sender, EventArgs e)
        {
          textBox1.TextChanged += new System.EventHandler(this.CheckTextBox);
          textBox2.TextChanged += new System.EventHandler(this.CheckTextBox);
        }
