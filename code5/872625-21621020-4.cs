        private string guess = "";
        public void GuessCheck()
        {
            System.Windows.Forms.MessageBox.Show("You clicked letter " + guess);
        }
        private void Any_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            b.Enabled = false;
            guess = b.Text;
            GuessCheck();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            int top = 50;
            int left = 100;
            for (int i = 'A'; i <= 'Z'; ++i)
            {
                var b = new System.Windows.Forms.Button();
                b.Text = System.Convert.ToChar(i).ToString();
                b.Name = "btn" + b.Text;
                b.Left = left;
                b.Top = top;
                left += b.Width + 2;
                b.Click += Any_Click;
                this.Controls.Add(b);
            } // Next i 
        } // End Sub Form1_Load
