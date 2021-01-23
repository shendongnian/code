    public static class Enumerable
    {
        public static TResult[,] ToRectangularArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult[]> selector)
        {
            // check if source is null
            if (source == null)
                throw new ArgumentNullException("source");
            // load all items from source and pass it through selector delegate
            var items = source.Select(x => selector(x)).ToArray();
            // check if we have any items to insert into rectangular array
            if (items.Length == 0)
                return new TResult[0, 0];
            // create rectangular array
            var width = items[0].Length;
            var result = new TResult[items.Length, width];
            TResult[] item;
            for (int i = 0; i < items.Length; i++)
            {
                item = items[i];
                // item has different width then first element
                if (item.Length != width)
                    throw new ArgumentException("TResult[] returned by selector has to have the same length for all source collection items.", "selector");
                for (int j = 0; j < width; j++)
                    result[i, j] = item[j];
            }
            return result;
        }
    }
