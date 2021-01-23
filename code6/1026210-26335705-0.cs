    class Program
        {
            static void Main(string[] args)
            {
                List<string> list = new List<string>();
                list.Add("Bill cat had");
                list.Add("Bill had a cat");
                list.Add("Bill had cat");
                list.Add("Cat had Bill");
                Regex rex = new Regex(@"((Bill)).*((had)).*((cat))");
                
                foreach (string str in list)
                {
                    if (rex.IsMatch(str))
                    {
                        Console.WriteLine(str);
                    }
                }
                Console.ReadLine();
            }
        }
