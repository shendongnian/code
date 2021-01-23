    public static void cubicPairs(double n)
    {
        double root = (System.Math.Pow(n, (1/3)));
        double roundedRoot = Math.Round(root);
        if (Math.Abs(roundedRoot - root) < VERY_SMALL_NUMBER)
            return roundedRoot;
        else
            return root;
    }
