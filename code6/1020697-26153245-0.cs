    private void fanSlider_Scroll(object sender, EventArgs e)
    {
        lblFS.Text = "" + fanSlider.Value * 5;
        if (lblFS.Text == "0")
        {
            lblFS.Text = "Automatic";
            lblFS.ForeColor = System.Drawing.Color.Black;
        }
        int value;
        if (Int32.TryParse(lblFS.Text, out value))
        {
            if (value <= 35)
            {
                lblFS.ForeColor = System.Drawing.Color.Red;
            }
            if (value > 35)
            {
                lblFS.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
