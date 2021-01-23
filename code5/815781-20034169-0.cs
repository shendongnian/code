    uint iBinaryNum = 2; //To store binary number
    decimal iDecimalNum; //To store decimal numbers
    //Validation of user choice & main program
    while (iBinaryNum > 1)
    {
        Console.Write("Enter the binary number you want to convert to decimal: ");
        if (!uint.TryParse(Console.ReadLine(), out iBinaryNum))
        {
            //If it's not equal to 0 or 1
            Console.WriteLine("Invalid binary number, Please re-enter");
            iBinaryNum = 2;
        }
    }
    iDecimalNum = Convert.ToDecimal(iBinaryNum);
    Console.WriteLine("This converted into decimal is " + iDecimalNum);
