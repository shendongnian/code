    public double[] redrawArray(double[] ary, int selectedIndex)
    {
        double[] redoneArray = new double[ary.GetUpperBound(0)];
        Array.Copy(ary, redoneArray, selectedIndex);
        Array.Copy(ary, selectedIndex + 1, 
                   redoneArray, selectedIndex, redoneArray.Length - selectedIndex);
        return redoneArray;
    }
