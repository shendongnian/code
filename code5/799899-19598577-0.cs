    Square[] squares = new Square[64];
    public class Square
    {
        public Point Location { get; set; }
        public Piece Resident { get; set; }
    }
    public enum TeamColor
    {
        Red,
        Black
    }
    public abstract class Piece
    {
        public TeamColor Color { get; set; }
        public Square Location { get; set; }
        
        public abstract Square[] MovesAllowed(Square[] allSquares);
    }
    public class King : Piece
    {
        public override Square[] MovesAllowed(Square[] allSquares)
        {
            ...
        }
    }
