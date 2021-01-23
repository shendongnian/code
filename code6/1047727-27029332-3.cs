    for (int i = 0; i < a.GetUpperBound(1)-1; ++i)
    {
        for (int j = i; j < a.GetUpperBound(1); ++j)
        {
            if (a[i,0] > a[j,0])
            {
                // swap a[i] and a[j]
                for (int x = 0; x < a.GetUpperBound(1); ++x)
                {
                    string temp = a[i,x];
                    a[i,x] = a[j,x];
                    a[j,x] = temp;
                }
            }
        }
    }
