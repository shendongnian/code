    private static String GetRatio(Double MaxSizeH, Double MaxSizeV)
    {
        if (MaxSizeV == 0)
        {
            return "undefined";
        }
        Double ratio = MaxSizeH / MaxSizeV;
        String strRatio = "4/3";
        Double ecartRatio = Math.Abs(ratio - (4 / (Double)3));
        if (Math.Abs(ratio - (16 / (Double)10)) < ecartRatio)
        {
            ecartRatio = Math.Abs(ratio - (16 / (Double)10));
            strRatio = "16/10";
        }
        if (Math.Abs(ratio - (16 / (Double)9)) < ecartRatio)
        {
            ecartRatio = Math.Abs(ratio - (16 / (Double)9));
            strRatio = "16/9";
        }
        return strRatio;
    }
    // diagonal in inch
    private static Double GetDiagonale(Double MaxSizeH, Double MaxSizeV)
    {
        return 0.3937 * Math.Sqrt(MaxSizeH * MaxSizeH + MaxSizeV * MaxSizeV);
    }
