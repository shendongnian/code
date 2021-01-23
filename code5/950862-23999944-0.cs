    using System;
    using MathNet.Numerics;
    using MathNet.Numerics.LinearAlgebra.Double;
    using System.Globalization;
    
    namespace Examples.LinearAlgebraExamples
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Format matrix output to console
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                formatProvider.TextInfo.ListSeparator = " ";
    
                // Create random square matrix
                var matrix = new DenseMatrix(5);
                var rnd = new Random(1);
                for (var i = 0; i < matrix.RowCount; i++)
                {
                    for (var j = 0; j < matrix.ColumnCount; j++)
                    {
                        matrix[i, j] = rnd.NextDouble();
                    }
                }
    
                Console.WriteLine(@"Initial matrix");
                Console.WriteLine(matrix.ToString("#0.00\t", formatProvider));
                Console.WriteLine();
    
                // 1. Get matrix inverse
                var inverse = matrix.Inverse();
                Console.WriteLine(@"1. Matrix inverse");
                Console.WriteLine(inverse.ToString("#0.00\t", formatProvider));
                Console.WriteLine();
    
    // removed examples here
    
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
