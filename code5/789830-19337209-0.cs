        addTemperature = Double.Parse(txttemp.Text);
        lblans.Text = addTemperature.ToString();
        if (addTemperature < 15)
        {
            lblans.ForeColor = System.Drawing.Color.Blue;
        }
        else
        {
            lblans.ForeColor = System.Drawing.Color.Red;
        }
