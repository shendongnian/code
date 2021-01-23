    static void Main()
        {
            //Declare variables
            double[,] dblZipArray = { { 40214, 5.00 }, { 40245, 4.85 }, { 40248, 2.67 }, { 40272, 3.79 }, { 40299, 5.40 }, { 42103, 2.30 }, { 42133, 4.60 }, { 42141, 1.00 }, { 42160, 1.45 }, { 42303, 3.60 } };
            double dblUserZIP;
            
            Console.Clear();
            //Ask user for zip code
            Console.WriteLine("Please enter a ZIP code to view the delivery charge for that area.");
            dblUserZIP = Convert.ToDouble(Console.ReadLine());
            int zip;
            
            for (zip = 0; zip < dblZipArray.Length / 2; zip++ )
            {
                if (dblZipArray[zip,0] == dblUserZIP)
                {
                    break;
                }
            }
                if (zip == dblZipArray.Length /2)
                {
                    Console.WriteLine("ZIP Code {0} is not in our delivery area.", dblUserZIP);
                }
                else
                {
                    Console.WriteLine("The price of delivery to ZIP code {0} is ${1}", dblUserZIP, dblZipArray[zip, 1]);
                }
            Console.ReadLine();
        }
