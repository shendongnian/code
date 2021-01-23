    double[] doubleArray = strArray.Select(s => Double.Parse(s)).ToArray();
    int k = 0;
            
    for (int i = GlobalDataClass.Array.GetLowerBound(0); i <= GlobalDataClass.Array.GetUpperBound(0); i++)
    {
        for (int j = GlobalDataClass.Array.GetLowerBound(1); j <= GlobalDataClass.Array.GetUpperBound(1); j++)
        {
            double d = doubleArray[k];
            GlobalDataClass.Array.SetValue(d, i, j);
            k++;
        }
    }
