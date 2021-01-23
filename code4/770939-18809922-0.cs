    public static double[] redrawArray(double[] ary, int selectedIndex) {
        double[] redoneArray = new double[ary.GetUpperBound(0)];
        Array.Copy(ary, redoneArray, ary.GetUpperBound(0)); // copy the source into the destination minus one..
        for (int i = selectedIndex; i < ary.GetUpperBound(0); i++) {
            redoneArray[i] = ary[i + 1];
        }
        return redoneArray;
    }
