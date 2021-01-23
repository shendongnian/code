    static void Main(string[] args)
        {
            var bingoCard = getBingoCard();
            int colNum = 1;
            foreach(var col in bingoCard)
            {
                Console.Write("col" + colNum.ToString() + " ");
                foreach(var item in col)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                colNum++;
            }
            Console.ReadLine();
        }
        public static int[][] getBingoCard()
        {
            var randGen = new Random();
            var bingoCard = new int[][]{
                new int[5],
                new int[5],
                new int[5],
                new int[5],
                new int[5]
            };
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    var possibleNumber = randGen.Next((15 * y) + 1, ((y + 1) * 15));
                    while (bingoCard[y].Any(num => num == possibleNumber))
                    {
                        possibleNumber = randGen.Next((15 * y) + 1, ((y + 1) * 15));
                    }
                    bingoCard[y][x] = possibleNumber;
                }
            }
            return bingoCard;
        }
