    static void Main(string[] args)
        {
            Console.WriteLine(Math.Round(1122.454540000, 4).ToString("N4"));  // output 1122.4545
            Console.WriteLine(Math.Round(1122.000100, 4).ToString("N4")); // output 1122.0001
            Console.WriteLine(Math.Round(9876.000000, 4).ToString("N4"));// output 9876.0000
            Console.WriteLine(Math.Round(1122.4000, 4).ToString("N4"));// output 1122.4000
            Console.WriteLine(Math.Round(1122.5400, 4).ToString("N4"));// output 1122.5400
                Console.ReadLine();
         
        }
