    public static class MyTypeExtensions
    {
        public static IEnumerable<MyType> FilterOnStopOrder(this IEnumerable<MyType> source)
        {
            MyType previous = null;
            foreach (var item in source.OrderBy(s => s.ID))
            {
                // or whatever condition... 
                if (previous != null && previous.StopOrder < item.StopOrder)
                {
                    yield return item;
                }
                previous = item;
            }
        }
    }
