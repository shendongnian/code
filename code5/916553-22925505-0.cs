    class Program
    {
        delegate double MyCos(double x);
        static void Main(string[] args)
        {
            MyCos cos = new MyCos(Math.Cos);
            Console.WriteLine(cos(Math.PI));           
        }
    }
