    private int getLastRowCount()
    {
        return dg.Rows.Count;
    }
    
    double[] minAmounts = new double[getLastRowCount()];
    double[] maxAmounts = new double[getLastRowCount()];
    double[] chrgeValues = new double[getLastRowCount()];
    
    for (int ctr = 0; (ctr < getLastRowCount()); ctr++)
    {
        //minAmounts[ctr] = Convert.ToDouble(dg[0, ctr].Value);
        //maxAmounts[ctr] = Convert.ToDouble(dg[1, ctr].Value);
        //chrgeValues[ctr] = Convert.ToDouble(dg[2, ctr].Value);
        // it should be [row, col]. This assumes you have at least 3 columns.
        minAmounts[ctr] = Convert.ToDouble(dg[ctr, 0].Value);
        maxAmounts[ctr] = Convert.ToDouble(dg[ctr, 1].Value);
        chrgeValues[ctr] = Convert.ToDouble(dg[ctr, 2].Value);
    }
