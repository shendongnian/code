    int[,] matrix = new int[2, 2] {{2,2},{1,1} };
                //subsitute values of 2nd row
                for (int i = 0; i < matrix.GetLength(0);i++ )
                {
                    //subsitute values of 1st row,matrix(array),GetLenght()putting values
                    for (int k = 0; k < matrix.GetLength(1);k++ )
                    {
                        //put a single value
                        Console.Write(matrix[i,k]);
                    }
                    //next row
                    Console.WriteLine();
                }
