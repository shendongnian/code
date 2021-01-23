    private void UpdateButton()
    {
        if (clicks > 5)
            button1.Enabled = true;
        else button1.Enabled = false;
        // This function can be reduced to one line of code:
        // button1.Enabled = clicks > 5;
    }
