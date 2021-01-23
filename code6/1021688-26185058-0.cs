        static void Main()
        {
            //Declare variables
            Dictionary<int, double> zipDic = new Dictionary<int, double> { { 40214, 5.00 }, { 40245, 4.85 }, { 40248, 2.67 }, { 40272, 3.79 }, { 40299, 5.40 }, { 42103, 2.30 }, { 42133, 4.60 }, { 42141, 1.00 }, { 42160, 1.45 }, { 42303, 3.60 } };
            Console.Clear();
            //Ask user for zip code
            Console.WriteLine("Please enter a ZIP code to view the delivery charge for that area.");
            var zipCode = int.Parse(Console.ReadLine());
            if (!zipDic.ContainsKey(zipCode))
            {
                Console.WriteLine("ZIP Code {0} is not in our delivery area.", zipCode);
            }
            else
            {
                Console.WriteLine("The price of delivery to ZIP code {0} is ${1}", zipCode, zipDic[zipCode]);
            }
            Console.ReadLine();
        }
