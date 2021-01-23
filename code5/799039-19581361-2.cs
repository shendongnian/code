    static void Main(string[] args)
    {
        int[] arr = new int[10];
        int count = 0;
        int a;
        do
        {
            if (int.TryParse(Console.ReadLine(), out a)) //Verify that input is numeric
            {
                if ((a > 10) && (a < 100))  //Check Constraints
                {
                    if (!arr.Contains(a))   //Check for duplicates
                    {
                        arr[count] = a;    //Only if we get here then input into array
                        count++;           //Increment to next Index
                    }
                }
            }
        } while (count < 10);             //Rinse and repeat to you get 10 valid entries
        Console.ReadLine();
    }
