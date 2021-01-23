    class FinishedPiece
    {
        private double _PieceLength;
        public double PieceLength
        {
            get { return _PieceLength; }
            set { _PieceLength = value; }
        }
    
        public Cut Cut { get; set; }
    }
