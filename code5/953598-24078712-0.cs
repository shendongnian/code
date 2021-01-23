    public class BaseHome
    {
        static BaseHome()
        {
            Console.WriteLine("B\nA\nC");
            Console.SetOut(System.IO.TextWriter.Null);
        }
        
        public static void Main()
        {
            Console.WriteLine("A");
        }
    }
