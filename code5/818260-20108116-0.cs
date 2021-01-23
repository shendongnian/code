    public sealed class GenericComparer<T> : IComparer<T>
    {
        public enum SortOrder
        {
            Ascending = 0,
            Descending = 1
        }
        private string sortColumn;
        private SortOrder sortingOrder;
        public string SortColumn
        {
            get
            {
                return this.sortColumn;
            }
        }
        public SortOrder SortingOrder
        {
            get
            {
                return this.sortingOrder;
            }
        }
        public GenericComparer(string theSortColumn, SortOrder theSortingOrder)
        {
            this.sortColumn = theSortColumn;
            this.sortingOrder = theSortingOrder;
        }
        public int Compare(T x, T y)
        {
            PropertyInfo thePropertyInfo = typeof(T).GetProperty(this.sortColumn);
            IComparable object1 = (IComparable)thePropertyInfo.GetValue(x, null);
            IComparable object2 = (IComparable)thePropertyInfo.GetValue(y, null);
            if (this.sortingOrder == SortOrder.Ascending)
            {
                return object1.CompareTo(object2);
            }
            else
            {
                return object2.CompareTo(object1);
            }
        }
    }
