    public class Matrix
    {
        double[,][] matrix;
        public Matrix(int groupSize, int columnSize)
        {
            matrix = new double[groupSize, columnSize][];
        }
        public void Add(double[] arr, int groupIndex, int columnIndex)
        {
            matrix[groupIndex, columnIndex] = arr;
        }
        public void Print()
        {
            int columnIndex = 0;
            int groupIndex = 0;
            int groupSize = matrix.GetLength(0);
            int columnSize = matrix.GetLength(1);
            while (groupIndex < groupSize)
            {
                for (int k = 0; k < matrix[groupIndex, columnIndex].Length; k++)
                {
                    Console.Write(groupIndex + 1);
                    while (columnIndex < columnSize)
                    {
                        Console.Write("        {0}", matrix[groupIndex, columnIndex][k]);
                        columnIndex++;
                    }
                    Console.WriteLine();
                    columnIndex = 0;
                }
                groupIndex++;
            }
        }
    }
