    using System;
    namespace MultiplyTest
    {
        public class ConsoleTest
        {
            //CONSTANT ARRAY LENGTH
            public const int multiTable = 4;
            //ARRAY
            public int[,] multiplicationTableArr = new int[multiTable, multiTable];  // 4 x 4 table 
            public ConsoleTest()
            {
                MultiplicationTable();
            }
            //MULTIPLICATION METHOD
            private void MultiplicationTable()
            {
                for (int r = 0; r < multiTable; r++)
                {
                    //NESTED FOR LOOP
                    for (int c = 0; c < multiTable; c++)
                    {
                        multiplicationTableArr[r, c] = (r + 1) * (c + 1);
                    }//NESTED FOR LOOP ENDS
                }
            }
            // SEACHFORVALUE METHOD
            public string seachForValue(int intSearchNumber)
            {
                var result = string.Empty;
                for (int r = 0; r < multiplicationTableArr.GetLength(0); r++)
                {
                    for (int c = 0; c < multiplicationTableArr.GetLength(1); c++)
                    {
                        if (intSearchNumber == multiplicationTableArr[r, c])
                        {
                            result = result + r + ", " + c;
                        }
                    }//NESTED FOR LOOP ENDS
                }
                return result;
            }
        }
        internal class Program
        {
            public static void Main(string[] args)
            {
                var test = new ConsoleTest();
                Console.WriteLine(test.seachForValue(9));
            }
        }
    }
