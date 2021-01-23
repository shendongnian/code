    public static partial class SOExtensions
    {
        public static List<T> ToList2<T>(this object Input)
        {
            if (Input is IEnumerable)
                return ((IEnumerable)Input).Cast<T>().ToList();
            return new List<T>() { (T)Input };
        }
    }
