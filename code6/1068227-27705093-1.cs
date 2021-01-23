    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3 };
            // uses the IEnumerable overload -- prints false
            Console.WriteLine(array.HasChanged(array, (int x, int y) => x == y));
            // uses the IEnumerable overload -- prints false
            Console.WriteLine(array.HasChanged(array, (x, y) => x >= y));
            // uses the generic overload -- prints true
            Console.WriteLine(array.HasChanged(array, (x, y) => x == y));
            
            Console.ReadLine();
        }
    }
    static class Extensions
    {
        public static bool HasChanged<T>(this IEnumerable<T> obj1, IEnumerable<T> obj2, Func<T, T, bool> isEqualExpression)
        { 
            return false; 
        }
        public static bool HasChanged<T>(this T obj1, T obj2, Func<T, T, bool> equalityExpression)
        { 
            return true; 
        }
    }
