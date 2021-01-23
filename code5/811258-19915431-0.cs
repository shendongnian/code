    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, int>();
            products.Add("rice", 50);
            products.Add("chip", 20);
            products.Add("hat", 50);
            products.Add("ball", 34);
            
            Console.WriteLine("What product would you like?");
            var request = Console.ReadLine();
            int value;
            if (request != null)
            {
                if (products.TryGetValue(request, out value))
                {
                    Console.WriteLine("You've  selected: " + request + ". Value is: " + value);
                }
                else
                {
                    Console.WriteLine("You've  selected: " + request + ". There is no such item");
                }
            }
            Console.ReadKey();
        }
    }
