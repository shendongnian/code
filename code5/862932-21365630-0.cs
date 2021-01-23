        public class ExampleClass
        {
            public static int PublicStaticInt { get; set; }
            public int PublicInt { get; set; }
        }
        private static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                var example = new ExampleClass();
                Console.WriteLine("PublicStaticInt = " + ExampleClass.PublicStaticInt.ToString() + ", PublicInt = " + example.PublicInt);
                ExampleClass.PublicStaticInt++;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
