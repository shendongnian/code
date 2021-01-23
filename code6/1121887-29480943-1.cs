    class PropertyComparer<T> : IComparer<T>
    {
        private readonly Func<T, IComparable> _selector;
        public PropertyComparer(string propertyName)
        {
            var selectorParameter = Expression.Parameter(typeof (T), "x"); //parameter [T x]
            var property = Expression.PropertyOrField(selectorParameter, propertyName); // [x.Property]
            var cast = Expression.Convert(property, typeof(IComparable)); // [x.Property as IComparable]
            this._selector = Expression.Lambda<Func<T, IComparable>>(cast, selectorParameter).Compile();
        }
        public int Compare(T x, T y)
        {
            var left = this._selector(x);
            var right = this._selector(y);
            if (left == null)
            {
                if (right == null)
                    return 0;
                else
                    return -right.CompareTo(null);
            }
            else
            {
                return left.CompareTo(right);
            }
        }
    }
