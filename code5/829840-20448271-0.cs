    public class Program
    {
        public static void Main(string[] args)
        {
            WriteItems("a string", (byte)1, 3f, new object());
        }
        
        private static void WriteItems(params dynamic[] items)
        {
            foreach(dynamic item in items)
            {
                Write(item);
            }
        }
        
        private static void Write(byte b)
        {
            Console.WriteLine("Write byte: {0}", b);
        }
        
        private static void Write(float f)
        {
            Console.WriteLine("Write Single: {0}", f);
        }
        
        private static void Write(string s)
        {
            Console.WriteLine("Write string: {0}", s);
        }        
        
        private static void Write(object o)
        {
            Console.WriteLine("Write object: {0}", o);
        }
    }
