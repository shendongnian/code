    max = Int32.MinValue;
    for(i = 1; i < n; i++)
    {
        x=Convert.ToDouble(lbprices.Items[i]);
        if (x > max)
        {
            max = x;
        }                
    }
    min = Int32.MaxValue;
    for(j=1;j<l;j++)
    {
        y = Convert.ToDouble(lbprices.Items[j]);
        if (y < min)
        {
            min = y;
        }
    }
