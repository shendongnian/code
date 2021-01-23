        private void Form1_Load(object sender, EventArgs e)
        {
            Button newBtn = new Button();
            newBtn.Width = 25;
            newBtn.Height = 25;
            newBtn.Visible = true;
            Point p = new Point(100, 100);
            newBtn.Text = "Test";
            newBtn.Location = p;
            
            this.Controls.Add(newBtn);
        }
