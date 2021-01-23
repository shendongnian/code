                int a = 1;
                int b = 2;
                int c = 5;
                int d = 1;
                int f = 1;
                var listOfNumbers = new List<int> {a, b, c, d, f};
                
                var dict = new Dictionary<int, int>();
                foreach (var number in listOfNumbers)
                {
                    if (dict.ContainsKey(number))
                    {
                        dict[number] = dict[number] + 1; //if a key repeats => increment the value by 1
                        if (dict[number] == 3)
                            break; //found the number
                    }
                    else
                        dict.Add(number, 1); //for first occurence of the key => initialize the value with 1 
                }
 
