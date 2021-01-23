    private void controlToMakeInvisible_Click(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(Control))
        {
            ((Control)sender).Visible = false;
        }
    }
