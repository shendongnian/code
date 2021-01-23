    public class PropertyComparer<T> : IComparer<T>
    {
        private PropertyDescriptor PropDesc = null;
        private ListSortDirection Direction = ListSortDirection.Ascending;
        public PropertyComparer(string property, ListSortDirection direction)
        {
            T item = default(T);
            PropDesc = TypeDescriptor.GetProperties(item)[property];
            Direction = direction;
            Type interfaceType = PropDesc.PropertyType.GetInterface("IComparable");
            if (interfaceType == null && PropDesc.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(PropDesc.PropertyType);
                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }
            if (interfaceType == null)
            {
                throw new NotSupportedException("Cannot sort by " + PropDesc.Name +
                    ". This" + PropDesc.PropertyType.ToString() +
                    " does not implement IComparable");
            }
        }
        int IComparer<T>.Compare(T x, T y)
        {
            object xValue = PropDesc.GetValue(x);
            object yValue = PropDesc.GetValue(y);
            IComparable comparer = (IComparable)xValue;
            if (Direction == ListSortDirection.Ascending)
            {
                return comparer.CompareTo(y);
            }
            else
            {
                return -1 * comparer.CompareTo(y);
            }
        }
    }
