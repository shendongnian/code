    public static class Extensions 
    {
        public static T[] Add<T>(this T[] _self, T item)
        {
            return _self.Concat(new T[] { item }).ToArray();
        }
    }
    public class Program
    {
        public static void Main()
        {
            string[] test = { "Hello" };
            test = test.Concat(new string[] { "cruel" }).ToArray();
            test = test.Add("but funny");
            Console.WriteLine(String.Join(" ", test) + " world");
        }
    }
