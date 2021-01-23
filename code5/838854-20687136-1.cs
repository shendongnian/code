    public static int GetArrayOfIntegers(int[] anArray)
    {
        string strValue;
        int counter = 0;
        Console.Write("\t\n Enter an enteger from 0 - 10 :");
        strValue = Console.ReadLine();
        int i = 0;
        while (strValue != "-99")
        {
            anArray[i] = int.Parse(strValue);
            counter = counter + 1;
            if (anArray[i] >= 0 && anArray[i] <= 10)
            {
                Console.Write("\t\n Enter an enteger from 0 - 10 :");
                strValue = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\t\n Please try again entering an integer in the range (0 - 10) only,");
                Console.Write("\t\n Enter an enteger from 0 - 10 :");
                strValue = Console.ReadLine();
            }
            i++;
        }
        
