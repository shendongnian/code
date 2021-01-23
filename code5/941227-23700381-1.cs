    public void Stop_Click(object sender, EventArgs e)
    {
        if (Status.Text == "on")
        {
            Status.Text = "off";
            MyTimer.Enabled = false;
        }
        else if (Status.Text == "off")
        {
            Status.Text = "on";
            MyTimer.Enabled = true;
        }
    }
