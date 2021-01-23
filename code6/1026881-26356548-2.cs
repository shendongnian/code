    static void Main(string[] args)
    {
        bool keepPrompting = true;
        while (keepPrompting)
        {
            bool weHaveValidXValue = false;
            int x = 0, y = 0;
            while (!weHaveValidXValue)
            {
                Console.WriteLine("Enter value for X and press return:");
                string xValue = Console.ReadLine();
                weHaveValidXValue = int.TryParse(xValue, out x);
                if (!weHaveValidXValue || x <= 0)
                {
                    weHaveValidXValue = false;
                    Console.WriteLine("Invalid value");
                }
            }
            bool weHaveValidYValue = false;
            while (!weHaveValidYValue)
            {
                Console.WriteLine("Enter value for Y and press return:");
                string yValue = Console.ReadLine();
                weHaveValidYValue = int.TryParse(yValue, out y);
                if(!weHaveValidYValue || y <= 0)
                {
                    weHaveValidYValue = false;
                    Console.WriteLine("Invalid value");
                }
            }
            Triangle myTriangle = new Triangle(x, y);
            Console.WriteLine("My Triangle Area = {0}", myTriangle.TriArea());
            Console.WriteLine("Continue? (y/n)");
            string response = Console.ReadLine();
            if(response.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                keepPrompting = false;
            }
        }
    }
          
