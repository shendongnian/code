    public double[] redrawArray(double[] ary, int selectedIndex)
    {
        double[] redoneArray = new double[ary.GetUpperBound(0)];
        Array.Copy(ary, 0, redoneArray, 0, selectedIndex);
        Array.Copy(ary, selectedIndex + 1, redoneArray, selectedIndex, redoneArray.Length - selectedIndex);
        return redoneArray;
    }
