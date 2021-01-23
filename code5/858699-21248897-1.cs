    o = o.OrderBy(x => x, new MyComparer());
...
    internal class CustomComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            if (x is string && y is string)
            {
                return ((string)x).CompareTo((string)y);
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
                return (Convert.ToDouble(x)).CompareTo(Convert.ToDouble(y));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        private bool IsNumber(object o)
        {
            var t = o.GetType();
            if (o is int || o is double || o is float || o is long)
                return true;
            return false;
        }
    }
