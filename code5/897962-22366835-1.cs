    private void select1_Click(object sender, EventArgs e)
    {
        if (!select1Down)
        {
            // ... stuff
            SendKeys.SendWait("{Tab}");
            select1.Enabled = false;
            select2.Enabled = false;
            select1Down = true;
        }
    }
