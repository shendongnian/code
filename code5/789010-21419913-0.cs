    static void Problem16()
    {
        int[] digits = new int[350];
        //we're doing multiplication so start with a value of 1
        digits[0] = 1;
        //2^1000 so we'll be multiplying 1000 times
        for (int i = 0; i < 1000; i++)
        {
            //run down the entire array multiplying each digit by 2
            for (int j = digits.Length - 2; j >= 0; j--)
            {
                //multiply
                digits[j] *= 2;
                //carry
                digits[j + 1] += digits[j] / 10;
                //reduce
                digits[j] %= 10;
            }
        }
            
        //now just collect the result
        long result = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            result += digits[i];
        }
        Console.WriteLine(result);
        Console.ReadKey();
    }
