    double[] doubleArray = strArray.Select(s => Double.Parse(s)).ToArray();
    int k = 0;
         
    Array my2DArray = Array.CreateInstance(typeof(double), 2, 3);
   
    for (int i = my2DArray.GetLowerBound(0); i <= my2DArray.GetUpperBound(0); i++)
    {
        for (int j = my2DArray.GetLowerBound(1); j <= my2DArray.GetUpperBound(1); j++)
        {
            double d = doubleArray[k];
            my2DArray.SetValue(d, i, j);
            k++;
        }
    }
