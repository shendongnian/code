        static void Main(string[] args)
        {
            string sBinaryNum; //To store binary number
            int iDecimalNum; //To store decimal numbers
            Console.WriteLine("Enter the binary number you want to convert to decimal");
            sBinaryNum = Console.ReadLine();
            Console.WriteLine("The Binary number you have entered is " + sBinaryNum);
            iDecimalNum = Convert.ToInt32(sBinaryNum, 2);
            Console.WriteLine("This converted into decimal is " + iDecimalNum);
            //Prevent program from closing
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
