    o = o.OrderBy(x => x, new MyComparer());
...
    internal class MyComparer: IComparer<object>
    {
        public int Compare(object x, object y)
        {
            if (x is string && y is string)
            {
                return ((string) x).CompareTo((string) y);
            }
            else if (x is string && IsNumber(y))
            {
                return -1;
            }
            else if (y is string && IsNumber(x))
            {
                return 1;
            }
            else if (IsNumber(x) && IsNumber(y))
            {
                return ((double) x).CompareTo((double) y);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        private bool IsNumber(object o)
        {
            var t = o.GetType();
            if (o is int || o is double || o is float)
                return true;
            return false;
        }
    }
