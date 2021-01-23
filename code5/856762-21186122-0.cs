    string y = String.Empty;
    string[] x={"A","B","C","D","F","G"};
    
    for(int i = 0; i < x.GetUpperBound(0); i++)
    {
        y = y + "," + x[i];
    }
    y = y.TrimEnd(',');
