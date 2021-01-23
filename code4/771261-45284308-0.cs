            #region even and odd numbers
            for (int x = 0; x <= 50; x = x + 2)
            {
                
                int y = 1;
                y = y + x;
                if (y < 50)
                {
                    Console.WriteLine("Odd number is #{" + x + "} : even number is #{" + y + "} order by Asc");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Odd number is #{" + x + "} : even number is #{0} order by Asc");
                    Console.ReadKey();
                }
               
            }
            //order by desc
            for (int z = 50; z >= 0; z = z - 2)
            {
                int w = z;
                w = w - 1;
                if (w > 0)
                {
                    Console.WriteLine("odd number is {" + z + "} : even number is {" + w + "} order by desc");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("odd number is {" + z + "} : even number is {0} order by desc");
                    Console.ReadKey();
                }
            }
