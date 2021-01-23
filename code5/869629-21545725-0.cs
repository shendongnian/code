        static void  letsMult(int [] myArray)
        {  
            int multip = 1;
            for (int a = 0; a < myArray.Length; a++ )
            {
                for (int b = a+1; b < myArray.Length; b++ )
                {
                  multip =  myArray[a] *= myArray[b];
                }
            }
            Console.WriteLine(multip);
        }
