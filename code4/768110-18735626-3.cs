    class Program
    {
        static void Main(string[] args)
        {
            double? d = null;
            Console.WriteLine(d.Equals<double>(0.0));
            d = 0.0;
            Console.WriteLine(d.Equals<double>(0.0));
            Console.Read();
        }
    }
    public static class NullableExtensions
    {
        public static bool Equals<T>(this T? left, T right) where T : struct, IEquatable<T>
        {
            if (!left.HasValue)
                return false;
            return right.Equals(left.Value);
        }
    }
