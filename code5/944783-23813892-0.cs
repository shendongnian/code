    static class FindIndexEnumerableExtension
    {
        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");
            int retVal = 0;
            foreach (var item in items)
            {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }
    }
    class YourClass
    {
        void YourMethod()
        {
            lstTeamSales.OrderBy(x => x.TotalSales).FindIndex(x => x.UserID == currentUserID);
        }
    }
