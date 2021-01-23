     class MainClass
        {
            public static void Main()
            {
                Task.Factory.StartNew(MainClass.test2);
                Task.Factory.StartNew(MainClass.Update);
                Console.ReadLine();
            }
            public static void test2()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine("Test");
                }
            }
            public static void Update()
            {
                while (true)
                {
                    Console.WriteLine("Hello");
                    System.Threading.Thread.Sleep(250);
                }
                
            }
        }
