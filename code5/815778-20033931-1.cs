           string strBinaryNum=""; //To store binary number
           int iDecimalNum; //To store decimal numbers
  
        
            Console.WriteLine("Enter the binary number you want to convert to decimal");
            strBinaryNum = Console.ReadLine();
            Console.WriteLine("The Binary number you have entered is " + strBinaryNum);
            iDecimalNum = Convert.ToInt32(strBinaryNum, 2);            
            Console.WriteLine("This converted into decimal is " + iDecimalNum);
        
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
