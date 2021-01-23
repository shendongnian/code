    class Program {
        static void Main(string[] args) {
            var buffer = new StringBuilder(666);
            PassStringOut(buffer, buffer.Capacity);
            Console.WriteLine(buffer.ToString());
            Console.ReadLine();
        }
        [DllImport("Example.dll")]
        private static extern bool PassStringOut(StringBuilder buffer, int capacity);
    }
