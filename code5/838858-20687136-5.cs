    public static int GetArrayOfIntegers(int[] anArray)
    {
        string strValue;
        int counter = 0;
        Console.Write("\t\n Enter an enteger from 0 - 10 :");
        strValue = Console.ReadLine();
        while (strValue != "-99")
        {
            int value = int.Parse(strValue);
            if (value >= 0 && value <= 10)
            {
                anArray[counter] = value;
                counter = counter + 1;
                Console.Write("\t\n Enter an enteger from 0 - 10 :");
                strValue = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\t\n Please try again entering an integer in the range (0 - 10) only,");
                Console.Write("\t\n Enter an enteger from 0 - 10 :");
                strValue = Console.ReadLine();
            }
        }
        return counter;
    }
