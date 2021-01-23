        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txttemp.Text.Trim()) >= 15)
            {
                lblans.Text = "Hot";
                lblans.ForeColor = System.Drawing.Color.Red;
            } 
            else 
            {
                lblans.Text = "Cold";
                lblans.ForeColor = System.Drawing.Color.Blue;
            }
        }
