    //The following are three ways to print any 2d arrays to console:
    int[,] twoDArray = new int[3, 4]{ {2,5,55,44},{10,45,5,22 },{ 67,34,56,77} };
                        Console.WriteLine("Array Code Out Method:1");
                        int rows = twoDArray.GetLength(0); // 0 is first dimension, 1 is 2nd 
                                                           //dimension of 2d array 
                        int cols = twoDArray.GetLength(1);
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                Console.Write("\t" + twoDArray[i, j]);
                                //output: 2       5       55      44      10      45      5       22      67      34      56      77
                            }
                        }
            
                        Console.WriteLine("Array Code Out Method: 2");
                        for (int x = 0; x <= twoDArray.GetUpperBound(0); x++)
                        {
                            for (int y = 0; y <= twoDArray.GetUpperBound(1); y++)
                            {
                                Console.Write("\t"+ twoDArray[x,y]);
                                //output: 2       5       55      44      10      45      5       22      67      34      56      77
                            }
                        }
            
                        Console.WriteLine("Array Code Out Method:3");
                        foreach (int items in twoDArray)
                        {
                            Console.Write(""+ "\t" +items);
                            //output:  2       5       55      44      10      45      5       22      67      34      56      77
                        }
            
                        //string example
                        string[,] friendNames = new string[,] { {"Rosy","Amy"},
                                                          {"Peter","Albert"}
                                                        };
                        foreach (string str in friendNames)
                        {
                            Console.WriteLine(str);
                        }
