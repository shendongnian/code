    using System.Collections.Generic;
    namespace JaggedArrayExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                //jagged array declaration
                int[][] array1;
                //jagged array declaration and assignment
                var array2 = new int[][] {
                              new int[] { 1, 2 },
                              new int[] { 3, 4 },
                              new int[] { 5, 6 },
                              new int[] { 7, 8 }
                            };
                //2D-array declaration
                int[,] array3;
                //2D-array declaration and assignment (implicit bounds)
                var array4 = new int[,] {{1, 2}, {3, 4}, {5, 6}, {7, 8}};
                //2D-array declaration and assignment (explicit bounds)
                var array5 = new int[4, 2] {{1, 2}, {3, 4}, {5, 6}, {7, 8}};
                //get rows and columns at index
                var r = GetRow(array2, 1); //second row {3,4}
                var c = GetColumn(array2, 1); //second column {2,4,6,8}
            }
            private static int[] GetRow(int[][] array, int index)
            {
                return array[index]; //retrieving the row is simple
            }
            private static int[] GetColumn(int[][] array, int index)
            {
                //but things get more interesting with columns
                //especially if jagged arrays are involved
                var retValue = new List<int>();
                foreach (int[] r in array)
                {
                    int ub = r.GetUpperBound(0);
                    if (ub >= index) //index within bounds
                    {
                        retValue.Add(r[index]);
                    }
                    else //index outside of bounds
                    {
                        retValue.Add(0); //default value?
                        //or you can throw an error
                    }
                }
                return retValue.ToArray();
            }
        }
    }
