    double[, ,] array3D = new double[2, 3, 3] { { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } } };
          
            List<List<List<double>>> topLevel = new List<List<List<double>>>();
            for (int a = 0; a < array3D.GetLength(0); a++)
            {
                List<List<double>> secondLevel = new List<List<double>>();
                for (int b = 0; b < array3D.GetLength(1); b++)
                {
                    List<double> thirdLevel = new List<double>();
                    for (int c = 0; c < array3D.GetLength(2); c++)
                    {
                        thirdLevel.Add(array3D[a, b, c]);
                    }
                    secondLevel.Add(thirdLevel);
                }
                topLevel.Add(secondLevel);
            }
