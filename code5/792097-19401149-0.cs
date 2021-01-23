    void Main()
    {
        int foo = 5;
        if (foo.Between(1, 10))
            Debug.WriteLine("> 1 and < 10");
        else
            Debug.WriteLine("?");
    }
    
    public static class Extensions
    {
        public static bool Between<T>(this T value, T lowNotIncluded, T highNotIncluded)
            where T : struct, IComparable<T>
        {
            return value.CompareTo(lowNotIncluded) > 0 && value.CompareTo(highNotIncluded) < 0;
        }
    }
