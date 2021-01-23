            int[] block = new int[5];
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (block[i] > block[i + 1])
                    {
                        Console.WriteLine(i);
                        //swap(ref block[i], ref block[i + 1]);}
                    }
                }
            }
 
