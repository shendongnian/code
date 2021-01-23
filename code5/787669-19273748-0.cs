    class FinishedPiece
    {
        private double _PieceLength;
        public double PieceLength
        {
            get { return _PieceLength; }
            set { _PieceLength = value; }
        }
        private Cut _Cut;
        public Cut Cut
        {
            get { return _Cut; }
            set { _Cut = value; }
        }
    }
    public enum Cut
    {
        Angle = 0,
        Straight = 1,
        AngleThenStraight = 2,
        StraightThenAngle = 3
    };
