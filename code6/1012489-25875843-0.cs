        using System;
        using System.Collections.Generic;
     
       public static class SeriesExtensions
    {
        public static IEnumerable<IEnumerable<T>> SplitToSeries<T>(this IEnumerable<T> source, Int32 seriesSize)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return TakeAsSeries(enumerator, seriesSize);
                }
            }
        }
        private static IEnumerable<T> TakeAsSeries<T>(IEnumerator<T> sourceEnumerator, Int32 seriesSize)
        {
            var count = 0;
            do
            {
                count += 1;
                yield return sourceEnumerator.Current;
            }
            while (count < seriesSize && sourceEnumerator.MoveNext());
        }
    }
