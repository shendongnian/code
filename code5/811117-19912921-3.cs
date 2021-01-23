    public class ChessSquare
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsBlack { get { return (Row + Column) %2 == 1; }}        
    }
