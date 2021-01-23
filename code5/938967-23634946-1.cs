    public class Puzzle
    {
        public List<Piece> Pieces {get; set;}
        public void Draw(Graphics graphics)
        {
            // draw all pictures with respect to z order
        }
        public Piece HitTest(Point point)
        {
            ... // hittest all pieces, return highest z-order or null
        }
    }
