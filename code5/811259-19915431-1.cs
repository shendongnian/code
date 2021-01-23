    class Program
    {
        static void Main(string[] args)
        {
            var products = new[,] { {"rice", "50"}, {"chip", "20"}, {"hat", "50"}, {"ball", "34"} }; 
            
            Console.WriteLine("What product would you like?");
            var request = Console.ReadLine();
            string value = null;
            if (request != null)
            {
                for (int i = 0; i < products.GetUpperBound(0); i++)
                {
                    if (products[i, 0] == request)
                    {
                        value = products[i, 1];
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                Console.WriteLine("You've  selected: " + request + ". Value is: " + value);
            }
            else
            {
                Console.WriteLine("You've  selected: " + request + ". No value found.");
            }
            Console.ReadKey();
        }
    }
