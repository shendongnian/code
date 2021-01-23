    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("SELECT 1, 2, 3, OR 4");
                var uI=int.Parse(Console.ReadLine());
                if (uI==1)
                {
                    Console.WriteLine("msg");
                } else if (uI==2)
                {
                    Console.WriteLine("msgg");
                }
                else if (uI==3)
                {
                    Console.WriteLine("msggg");
                }
                else if (uI==4)
                {
                    Console.WriteLine("msgggg");
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
