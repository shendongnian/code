    private void Reset_Tick(object sender, EventArgs e)
    {
        if (PerformClick.Enabled == false)
        {
            CountTxt.Text = "0";
            Count = 0;
        } 
    }
