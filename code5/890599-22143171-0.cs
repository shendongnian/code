    var array = list.OrderBy(x => x, new NullableIntComparer())
                .ToArray();
    class NullableIntComparer : IComparer<int?>
    {
        public int Compare(int? x, int? y)
        {
            if (x.HasValue && y.HasValue)
            {
                return x.Value.CompareTo(y.Value);
            }
            if (x.HasValue)
            {
                return -1;
            }
            if (y.HasValue)
            {
                return 1;
            }
            return 0;
        }
    }
