                int var_1 = 10;
                int var_2 = 100;
                int var_3 = 1000;
                int[] arr = new int[3];
    
                var dict = new Dictionary<string, int> 
                { 
                    { "var_1", var_1 },
                    { "var_2", var_2 },
                    { "var_3", var_3 }
                };
    
                Random rand = new Random();
                
                for (int i = 0; i < 3; i++)
                {
                    var suff = rand.Next(1, 4);
                    arr[i] = dict["var_" + suff];
                }
    
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(arr[i]);
                }
