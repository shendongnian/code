    private int MyComparison(string x, string y)
        {
            if (string.IsNullOrEmpty(x))
            {
                if (string.IsNullOrEmpty(y))
                {
                    // If x is null and y is null, they're 
                    // equal.  
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y 
                    // is greater.  
                    return 1;
                }
            }
            else
            {
                // If x is not null... 
                // 
                if (string.IsNullOrEmpty(y))
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                //sort them with ordinary string comparison
                else
                    return x.CompareTo(y);
            }
        }
    List<string> liststring = new List<string>() {"C", "","A","","B"};
    liststring.Sort(MyComparison);
