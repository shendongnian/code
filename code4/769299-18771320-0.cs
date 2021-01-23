        public class ChessSquare
        {
            public string Letter { get; set; }
            public int Number { get; set; }
            public Color Color { get; set; }
            public string Position
            {
                get { return string.Format("{0}{1}", Letter, Number); }
            }
            public ChessSquare()
            {
            }
            public ChessSquare(string letter, int number)
            {
                Letter = letter;
                Number = number;
            }
        }
