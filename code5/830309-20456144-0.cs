    //Say RandomArray comes {4,3,1,1,3}
            for (int i = 0; i < 5; ++i)
            {
                Count[RandomArray[i] - 1]++;
                //When i=0
               // RandomArray[i]=4
                //Count[RandomArray[i] - 1] will be Count[4-1] which will be Count[3]
                //++ increment the value by 1. initially all values are 0 for Count Array
                //so Count[3] will be 0++ which is equal to 1
                //so Count[3]=1
                
                //and so on for other indices.
            }
            for (int i = 0; i < 5; ++i)
            {
                //Here 0 format specifier is giving value of Count[i]
                //1 format specifier is giving value of Count[i]
                //2 is doing nothing since there is not corresponding parameter
                Console.Write("{0,2} Adet {1,2} >>>>", Count[i], i + 1);
                for (int j = 0; j < Count[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
