    public static class RecursiveSumExtension
    {
        public static int RecursiveSum(this IEnumerable items)
        {
            if (null == items)
                return 0;
            var total = 0;
            foreach (var item in items)
            {
                if (item is IEnumerable)
                    total += (item as IEnumerable).RecursiveSum();
                else
                    total++;
            }
            return total;
        }
    }
