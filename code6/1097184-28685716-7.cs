    public class ChessPiece
    {
        public bool onBoard { get; set; }    // is the piece standing on the board?
        public int row { get; set; }         // row
        public int col { get; set; }         // column
        public char piecetype { get; set; }  // a little simplistic..not used..
        public char color { get; set;}       // .. could be an enumeration!
        public int pieceIndex { get; set; }  // points into imageList with 12 images
        public ChessPiece(char color, char type, int r, int c, int ind)
        { onBoard = true; piecetype = type; this.color = color; 
          row = r; col = c; pieceIndex = ind; }
    }
