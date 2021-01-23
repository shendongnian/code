            //declaration of integer
            int TotalCount = 50;
            int loop;
            Console.WriteLine("\n---------Odd Numbers -------\n");
            for (loop = TotalCount; loop >= 0; loop--)
            {
                if (loop % 2 == 0)
                {
                    Console.WriteLine("Even numbers : #{0}", loop);
                }
   
            }
            Console.WriteLine("\n---------Even Numbers -------\n");
            for (loop = TotalCount; loop >= 0; loop--)
            {
                if (loop % 2 != 0)
                {
                    Console.WriteLine("odd numbers : #{0}", loop);
                }
            }
            
