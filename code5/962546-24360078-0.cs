    using System;
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var board = new Board();
                board.InitializeBoard();
            }      
        }
        public class Board
        {
            public Spot[,] gameBoardData { get; private set; }
            public Tile[] tileData { get; private set; }
            public void InitializeBoard()
            {
                this.gameBoardData = new Spot[4, 4];
                for (int row = 0; row < 4; row++)
                {
                    for (int column = 0; column < 4; column++)
                    {
                        this.gameBoardData[row, column] = new Spot();
                        this.gameBoardData[row, column].PieceState = 0;
                    }
                }
                Tile tile1 = new Tile(new Spot[4] { gameBoardData[0, 0], gameBoardData[0, 1], gameBoardData[1, 1], gameBoardData[1, 0] });
                Tile tile2 = new Tile(new Spot[4] { gameBoardData[0, 2], gameBoardData[0, 3], gameBoardData[1, 3], gameBoardData[2, 2] });
                Tile tile3 = new Tile(new Spot[4] { gameBoardData[2, 0], gameBoardData[2, 1], gameBoardData[3, 1], gameBoardData[3, 0] });
                Tile tile4 = new Tile(new Spot[4] { gameBoardData[2, 2], gameBoardData[2, 3], gameBoardData[3, 3], gameBoardData[3, 2] });
                this.tileData = new Tile[4] { tile1, tile2, tile3, tile4 };
                tileData[0].Spots[0].PieceState = 25;
                if (gameBoardData[0, 0].PieceState == 25)
                {
                    Console.WriteLine("Changes Reflected");
                    Console.Read();
                }
            }
        }
        public class Spot
        {
            public int PieceState { get; set; }
        }
        public class Tile
        {
            public Spot[] Spots;
            public Tile(Spot[] spots)
            {
                Spots = spots;
            }
        }
    }
