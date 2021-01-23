    public struct AbsolutePos
    {
        private const double SEC_FACTOR = int.MaxValue * 2d;
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
    
        public AbsolutePos(SectorPos secPos, LocalPos locPos)
        {
            X = secPos.X * SEC_FACTOR + locPos.X;
            Y = secPos.Y * SEC_FACTOR + locPos.Y;
            Z = secPos.Z * SEC_FACTOR + locPos.Z;
        }
        public double Distance(AbsolutePos pos)
        {
            // implement 3d distance calculation normally here
        }
    }
