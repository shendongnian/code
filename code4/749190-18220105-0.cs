    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            int result = StringComparer.InvariantCulture.Compare(x.Name, y.Name);
            if (result == 0)
            {
                result = Array.IndexOf(originalArray, x).CompareTo(Array.IndexOf(originalArray, y));
            }
            return result;
        }
    }
