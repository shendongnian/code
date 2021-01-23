    class Program
        {
            static void Main(string[] args)
            {
                Task[]t = new Task[100];
                for (int i = 0; i < 100; i++)
                {
                    var temp=i;
                    t[i] = Task.Factory.StartNew(() => print(temp));
                }
                Task.WaitAll(t);
                Console.WriteLine("complete");
                Console.ReadLine();
            }
        
            private static void print(object i)
            {
        
                Console.WriteLine((int)i);
            }
        }}
