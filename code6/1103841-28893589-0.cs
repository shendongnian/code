    private int getLastRowCount()
    {
        return dg.Rows.Count - 1; // let's assume this will return 5.
    }
    // here we declaring 3 arrays of the size 5.
    double[] minAmounts = new double[getLastRowCount()];
    double[] maxAmounts = new double[getLastRowCount()];
    double[] chrgeValues = new double[getLastRowCount()];
    // this loop will iterate 6 times: 0,1,2,3,4,5 since getLastRowRount() result to 5.
       for (int ctr = 0; (ctr <= getLastRowCount()); ctr++)
       {
            minAmounts[ctr] = Convert.ToDouble(dg[0, ctr].Value);
            maxAmounts[ctr] = Convert.ToDouble(dg[1, ctr].Value);
            chrgeValues[ctr] = Convert.ToDouble(dg[2, ctr].Value);
       }
