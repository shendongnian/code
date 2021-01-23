    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.IO;
    namespace MSquareTest
    {
        [TestClass]
        public class MSquareTest
        {
            /// <summary>
            /// Checks if array of int's
            /// is an magick square
            /// </summary>
            /// <param name="matrix">Input array</param>
            /// <returns>True/False</returns>
            public bool IsMagicSquare(int[] matrix)
            {
                if (matrix.Length % 3 != 0)
                    throw new ArgumentException("Invalid 2D cube!");
            
                // 2x2(6 cells) is minimum
                if (matrix.Length < 6)
                    throw new ArgumentException("Use at least 2x2 cube!");
                // Cube face length
                int length = matrix.Length / 3;
                // calculate first row sum
                int excepted = 0;
                for (int y = 0; y < length; y++)
                    excepted += matrix[y];
                // calculate and check second and another rows 
                for (int x = 1; x < length; x++)
                {
                    int actual = 0;
                    for (int y = 0; y < length; y++)
                        actual += matrix[(length * x) + y];
                    if (actual != excepted)
                        return false;
                }
                // calculate and check columns
                for (int x = 0; x < length; x++)
                {
                    int actual = 0;
                    for (int y = 0; y < length; y++)
                        actual += matrix[(length * y) + x];
                    if (actual != excepted)
                        return false;
                }
                return true;
            }
            [TestMethod]
            public void TestMS()
            {
                var GoodInput = "8,1,6;3,5,7;4,9,2";    // = File.ReadAllText("..\\..\\ms.txt");
                var GoodArray = (from x in GoodInput.Split(',', ';') select int.Parse(x)).ToArray();
                var BadInput = "6,4,1;3,0,3;1,5,9";
                var BadArray = (from x in BadInput.Split(',', ';') select int.Parse(x)).ToArray();
                // Good array is magick square, and bad array is not
                var Result = IsMagicSquare(GoodArray) && !IsMagicSquare(BadArray);
                Assert.IsTrue(Result);
            }
        }
    }
