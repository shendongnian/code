    public class DateValueCollection : List<DateValue>, IComparer<DateValue>
    {
        public DateValueCollection() { }
        public DateValueCollection(IEnumerable<DateValue> dateValues, bool isOrdered)
        {
            if (isOrdered)
                base.AddRange(dateValues);
            else
            {
                base.AddRange(dateValues.OrderBy(dv => dv.Date));
            }
        }
        private static IComparer<DateValue> comparer = new DateValueCollection();
        public DateValue GetNearest(DateTime date)
        {
            if (base.Count == 0)
                return default(DateValue);
            DateValue dv = new DateValue(date, 0);
            int index = base.BinarySearch(dv, comparer);
            if (index >= 0)
            {
                return base[index];
            }
            // If not found, List.BinarySearch returns the complement of the index
            index = ~index;
            DateValue[] all;
            if(index == base.Count - 1)
            {
                // proposed index is last, check previous and last
                all = new[] { base[index], base[index - 1] };
            }
            else if(index == 0)
            {
                // proposed index is first, check first and second
                all = new[] { base[index], base[index + 1] };
            }
            else
            {
                // return nearest DateValue from previous, this and next
                var thisDV = base[index];
                var prevDV = base[index - 1];
                var nextDV = base[index + 1];
                all = new[]{thisDV, prevDV, nextDV};
            }
            return all.OrderBy(x => (x.Date - date).Duration()).First();
        }
        public int Compare(DateValue x, DateValue y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
     
