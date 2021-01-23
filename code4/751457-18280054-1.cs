    public string FormattedBytes(long bytes)
    {
        string units = " kMGT";
        double logBase = Math.Log((double)bytes, 1024.0);
        double floorBase = Math.Floor(logBase);
        
        return String.Format("{0:N2}{1}b",
            Math.Pow(1024.0, logBase - floorBase),
            units.Substring((int)floorBase, 1));
    }
