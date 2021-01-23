        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                Control[] lbl = this.Controls.Find("label" + i, true);
                (lbl[0] as Label).Visible = false;
            
            }
        }
