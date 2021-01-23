    public class ChessBoard
    {
        public List<ChessSquare> Squares { get; private set; }
        public Command<ChessSquare> SquareClickCommand { get; private set; }
        public ChessBoard()
        {
            Squares = new List<ChessSquare>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares.Add(new ChessSquare() {Row = i, Column = j});
                }
            }
            SquareClickCommand = new Command<ChessSquare>(OnSquareClick);
        }
        private void OnSquareClick(ChessSquare square)
        {
            MessageBox.Show("You clicked on Row: " + square.Row + " - Column: " + square.Column);
        }
    }
