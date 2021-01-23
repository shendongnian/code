            int iBinaryNum; //To store binary number
            int iDecimalNum; //To store decimal numbers
    
            //Validation of user choice & main program
            if(iBinaryNum == 0 || iBinaryNum == 1)
            {
                Console.WriteLine("Enter the binary number you want to convert to decimal");
                iBinaryNum = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine("The Binary number you have entered is " + iBinaryNum);
                iDecimalNum = Convert.ToInt32(iBinaryNum, 2);
    
                Console.WriteLine("This converted into decimal is " + iDecimalNum);
            }
            else
            {
    
            //If it's not equal to 0 or 1
            Console.WriteLine("Invalid binary number, Please re-enter");
            }
            //Prevent program from closing
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
