    public class UxPicBox : PictureBox {
        public UxPicBox(int col, int row) : base() {
            this.Col = col;
            this.Row = row;
        }
        public int Col { get; set; }
        public int Row { get; set; }        
    }
