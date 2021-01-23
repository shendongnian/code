    public class Program
    {
        public static T Add<T>(T a, T b)
        {
            var paramA = Expression.Parameter(typeof (T), "a");
            var paramB = Expression.Parameter(typeof (T), "b");
            var body = Expression.Add(paramA, paramB);
            var add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            return add(a, b);
        }
        public delegate T del<T>(T x);
        //pass the variable s into the function instead of initializing it inside the function.
        public static T Sum<T>(T s, del<T> df, IEnumerable<T> data)
        {
            return data.Aggregate(s, (current, x) => Add(current, df(x)));
        }
        public static void Main(string[] args)
        {
            var data = Enumerable.Range(1, 4);
            int sum = Sum(0, x => x * x, data);
            Console.WriteLine(sum);
        }
    }
