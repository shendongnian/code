    // init with 0
    txtTableDollars.Text = 0;
    txtTableAvgTemp.Text = 0;
    double currentCost = 0;
    // do them outside, no need to do it on every loop
    float heatingVolume = float.Parse(txtVolume.Text);
    // working while
    while (poolDegrees >= 3.5 && poolDegrees < 23)
    {
        poolDegrees += poolTemp;
        double costToHeatPool = (25 - poolDegrees) * heatingVolume / 32500;
        currentCost += costToHeatPool;
        txtTableAvgTemp.Text += poolDegrees + System.Environment.NewLine;
        txtTableDollars.Text += currentCost + System.Environment.NewLine;
    }
