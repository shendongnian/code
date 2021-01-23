    class Program
    {
        public class Car
        {
            public int Id;
            public CarModel Model;
            public string Owner ;
        }
        public class CarModel
        {
            public string Name;
            public string Brand;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(ExpToString(x => x.Id));
            Console.WriteLine(ExpToString(x => x.Owner));
            Console.WriteLine(ExpToString(x => x.Model));
            Console.WriteLine(ExpToString(x => x.Model.Name));
            Console.WriteLine(ExpToString(x => x.Model.Brand));
        }
        // The inelegant solution that works
        public static string ExpToString<T>(Expression<Func<Car, T>> exp)
        {
            var s = exp.Body.ToString();
            return s.Remove(0, s.IndexOf('.') + 1);
        }
    }
