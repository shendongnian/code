    internal class Program
    {
        public static void Main(string[] args)
        {
            var test = new ConsoleTest();
            var v = test.seachForValue(12);
            Console.WriteLine(v);
            Console.ReadLine();
        }
    }
    public class ConsoleTest
    {
        public ConsoleTest()
        {
            MultiplicationTable();
        }
        //CONSTANT ARRAY LENGTH
        public const int TableSize = 12;
        //ARRAY
        public int[,] multiplicationTableArr = new int[TableSize, TableSize];  
        //MULTIPLICATION METHOD
        // this will intialize your array to your multiplication table 
        private void MultiplicationTable()
        {
            for (int row = 0; row < TableSize; row++)
            {
                //NESTED FOR LOOP
                for (int column = 0; column < TableSize; column++)
                {
                    multiplicationTableArr[row, column] = (row + 1) * (column + 1);
                }//NESTED FOR LOOP ENDS
            }
        }
        // SEACHFORVALUE METHOD
        public string seachForValue(int intSearchNumber)
        {
            var result = new StringBuilder();
            for (int row = 0; row < TableSize; row++)
            {
                for (int col = 0; col < TableSize; col++)
                {
                    if (intSearchNumber == multiplicationTableArr[row, col])
                    {
                        result.AppendLine("(" + row + ", " + col + ") -> " + (row + 1) + "*" + (col + 1 )+ "=" + intSearchNumber);
                    }
                }//NESTED FOR LOOP ENDS
            }
            return result.ToString();
        }
    }
