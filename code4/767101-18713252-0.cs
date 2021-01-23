    List<double> Result = new List<double>();
    for (int i = 0; i < 30; i++)
    {
        double firstVal = 0;
        double secondVal = 0;
        if (first.Count > i)
        {
            firstVal = first[i];
        }
        if (second.Count > i)
        {
            secondVal = second[i];
        }
        Result.Add(firstVal + secondVal);
    }
