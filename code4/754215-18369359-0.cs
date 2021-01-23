    public class ExcelNameComparer<T> : IComparer<IEnumerable<T>>
    {
        /// <summary>
        /// Create a sequence comparer using the default comparer for T.
        /// </summary>
        public ExcelNameComparer()
        {
            comp = Comparer<T>.Default;
        }
        /// <summary>
        /// Create a sequence comparer, using the specified item comparer
        /// for T.
        /// </summary>
        /// <param name="comparer">Comparer for comparing each pair of
        /// items from the sequences.</param>
        public ExcelNameComparer(IComparer<T> comparer)
        {
            comp = comparer;
        }
        /// <summary>
        /// Object used for comparing each element.
        /// </summary>
        private IComparer<T> comp;
        /// <summary>
        /// Compare two sequences of T.
        /// </summary>
        /// <param name="x">First sequence.</param>
        /// <param name="y">Second sequence.</param>
        public int Compare(IEnumerable<T> x, IEnumerable<T> y)
        {
            using (IEnumerator<T> leftIt = x.GetEnumerator())
            using (IEnumerator<T> rightIt = y.GetEnumerator())
            {
                while (true)
                {
                    bool left = leftIt.MoveNext();
                    bool right = rightIt.MoveNext();
                    if (!(left || right)) return 0;
                    if (!left) return -1;
                    if (!right) return 1;
                    int lengthResult = leftIt.Current.ToString().Length.CompareTo(rightIt.Current.ToString().Length);
                    if (lengthResult != 0) return lengthResult;
                    int itemResult = comp.Compare(leftIt.Current, rightIt.Current);
                    if (itemResult != 0) return itemResult;
                }
            }
        }
    Func<string, object> convert = str =>
    {
        try { return int.Parse(str); }
        catch { return str; }
    };
