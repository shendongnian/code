    private void Calculate();
    {
        dblUtil1 = Tinseth.Bigness(dblSG) * Tinseth.BTFactor(dblBT1);
        double UtilRounded1 = Math.Round(dblUtil1 * 100);
        lblUtil1.Text = UtilRounded1.ToString() + "%";
    }
