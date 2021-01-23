    class Program
    {
        static void Main(string[] args)
        {
    
            Console.WriteLine("Please enter string");
            string input = Convert.ToString(Console.ReadLine());
            Dictionary<string, int> objdict = new Dictionary<string, int>();
            foreach (var j in input.Split(" "))
            {
                if (objdict.ContainsKey(j))
                {
                    objdict[j] = objdict[j] + 1;
                }
                else
                {
                    objdict.Add(j, 1);
                }
            }
            foreach (var temp in objdict)
            {
                Console.WriteLine("{0}:{1}", temp.Key, temp.Value);
            }
            Console.ReadLine();
        }
    }
