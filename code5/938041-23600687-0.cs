    struct FrameData
    {
        public int FrameNumber;
        public string ObjectName;
        public int X, Y, Z;
        public FrameData(int frameNumber, string objectName, int x, int y, int z)
        {
            this.FrameNumber = frameNumber; this.ObjectName = objectName; this.X = x;
            this.Y = y; this.Z = z;
        }
    }
