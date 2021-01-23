    class Program
    {
        public static void Main(string[] args)
        {
            SayCatName(new Cat() { Name = "Whiskers" });
            Console.Read();
        }
        public static void SayCatName(Cat c)
        {
            Console.WriteLine(c.Name);
        }
    }
    public class Cat : IDisposable
    {
        public string Name { get; set; }
        public void Dispose()
        {
            Console.WriteLine("Cat was disposed");
        }
    }
