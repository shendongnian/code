    sealed class CustomComparer : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
            {
                char xc = x[i];
                char yc = y[i];
                if (xc == yc)
                    continue;
                char xcLow = char.ToLowerInvariant(xc);
                char ycLow = char.ToLowerInvariant(yc);
                if (xcLow == ycLow)
                {
                    if (xc < yc)
                        return 1;
                    else
                        return -1;
                }
                else if (xcLow < ycLow)
                    return -1;
                else
                    return 1;
            }
            return x.Length.CompareTo(y.Length);
        }
    }
