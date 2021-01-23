    class Program
    {
        static void With16Bit()
        {
            short a = 1;
            short b = 2;
            short c = (short) (a + b); // <- cast, since short + short = int
            Console.WriteLine(c);
        }
    
        static void With8Bit()
        {
            byte a = 1;
            byte b = 2;
            byte c = (byte) (a + b); // <- cast, since byte + byte = int
            Console.WriteLine(c);
        }
    
        static void Main(string[] args)
        {
            With8Bit();
            With16Bit();
        }
    }
