    struct Pos
    {
        ...
        public AbsolutePos GetAbsPos()
        {
            return new AbsolutePos(this.Sector, this.Local);
        }
    }
