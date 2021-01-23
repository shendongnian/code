            for (int i = 0; i < 10; i++)
            {
                //this loop will run 10 times.
                Console.WriteLine("int i = " + i.ToString()");
                for (int i1 = 0; i1 < 10; i++)
                {
                    // This will run 10 times every outer loop int.
                    // This means that for each index i in the outer loop this will run 10 times. 
                    // The outer loop runs 10 time and this runs 100 times.
                    Console.WriteLine("int i2 = " + i2.ToString()");
                }
            }
