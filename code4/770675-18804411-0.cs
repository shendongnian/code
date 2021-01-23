            void Select(string key)
            {
                for(int i=0;i<624;i++)
                {
                    if(census[i][0]==key)
                    {
                        Console.Write(census[i][1]);
                        Console.Write(census[i][2]);
                        Console.WriteLine();
                    }
                    
                }
            }
