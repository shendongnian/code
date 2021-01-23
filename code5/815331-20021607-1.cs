    public class Program
    {
        public string read = string.Empty;
        public string write = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine(AnyMethod().read + AnyMethod().write); 
        }
        public static Program AnyMethod()
        {
            Program p = new Program();
            p.read = "Asad";
            p.write = "ASAD";
            return p;
        }
    }
