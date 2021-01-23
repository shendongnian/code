    static class Extensions
    {
        /// <summary>
        /// N.B. ranges must be sorted by ascending Start, must contain 
        ///      non overlapping ranges and ranges with Start=End are not allowed.
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Range FindRangeContainingPoint(
            this IList<Range> ranges, int point)
        {
            if (ranges.Count == 0)
                return null;
            var index = ranges.FindFirstIndexGreaterThanOrEqualTo(
                        new Range(point, point + 1),
                        new StartOnlyRangeComparer());
            if (index < 0)
                return null; // no existing range contains the point, 
                             // if we wanted to insert a Range(point, point+1) 
                             // would be before the first element 
            if (index >= ranges.Count)
            {
                var lastElement = ranges[ranges.Count - 1];
                if (lastElement.ContainsPoint(point))
                    return lastElement;
                else
                    return null; // no existing range contains the point,  
                                 // if we wanted to insert a Range(point, point+1)
                                 // would be after the last element
            }
            if (ranges[index].ContainsPoint(point))
                return ranges[index];
            else if (index > 0 && ranges[index - 1].ContainsPoint(point))
                return ranges[index - 1];
            else
                return null; // no existing range contains the point,  
                             // if we wanted to insert a Range(point, point+1)
                             // would be at index - 1
        }
        /// <summary>
        /// Lower Bound function on sorted list (see credits)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortedCollection"></param>
        /// <param name="key"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int FindFirstIndexGreaterThanOrEqualTo<T>(
            this IList<T> sortedCollection,
            T key,
            IComparer<T> comparer)
        {
            int begin = 0;
            int end = sortedCollection.Count;
            while (end > begin)
            {
                int index = begin + ((end - begin) / 2);
                T el = sortedCollection[index];
                if (comparer.Compare(el, key) >= 0)
                    end = index;
                else
                    begin = index + 1;
            }
            return end;
        }
        /// <summary>
        /// Check if point is included in [Start, End)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool ContainsPoint(this Range range, int point)
        {
            return range.Start <= point && range.End > point;
        }
    }
