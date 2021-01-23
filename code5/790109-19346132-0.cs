                List<int> nums = new List<int>();
                double[,] matrix = new double[3,3];
                for (int i = 0; i < 9; ++i)
                {
                    double input;
                    Console.Write("Enter value");
                    while (!double.TryParse(Console.ReadLine(), out input))
                    {
                        Console.Write("Enter correct value!");
                    }
                    nums.Add(int.Parse(input.ToString()));
                }
                nums.Sort();
                int block = 0;
                int[] order = new int[] { 0, 1, 2, 2, 2, 1, 0, 0, 1 };
                for (int i = 0 ; i < order.Length; i++)
                {
                    switch (block)
                    {
                        case 0:
                            matrix[block, order[i]] = nums[i];
                            if (i == 2)
                                block = 1;
                            break;
                        case 1:
                            if (i < order.Length - 3)
                            {
                                matrix[block, order[i]] = nums[i];
                                block = 2;
                            }
                            else
                                matrix[block, order[i]] = nums[i];
                            break;
                        case 2:
                            if(i == order.Length - 3)
                            {
                                matrix[block, order[i]] = nums[i];
                                block = 1;
                            }
                            else
                                matrix[block, order[i]] = nums[i];
                            break;
    
                    }
                }
