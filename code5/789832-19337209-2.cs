    // If LESS than 15
    if (addTemperature < 15)
    {
        lblans.ForeColor = System.Drawing.Color.Blue;
    }
    // Else, meaning anything other is MORE than 15, you could also do:
    // else if (addTemperature >= 15), but that wouldn't be needed in this case
    else
    {
        lblans.ForeColor = System.Drawing.Color.Red;
    }
