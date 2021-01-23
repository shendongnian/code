    public double[] redrawArray(double[] ary, int selectedIndex)
    {
        double[] redoneArray = new double[ary.GetUpperBound(0)];
        int i = 0;
        for (; i < selectedIndex; i++)
        {
            redoneArray[i] = ary[i];
        }
        for (; i < redoneArray.Length; i++)
        {
            redoneArray[i] = ary[i + 1];
        }
        return redoneArray;
    }
