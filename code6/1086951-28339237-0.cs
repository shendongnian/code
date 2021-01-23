    public class Program
    {
        [DllImport(@"c:\mycpp.dll")]
   
        private static extern int Sum(int a, int b);
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(3,5));
        }
    }
