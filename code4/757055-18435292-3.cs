    namespace DrawingText
    {
        [Serializable]
        public class DrawingData
        {
            private Point mold; // mouseDown position
            private Point mcur; // mouseUp poslition
            private string randValue; // random data value
            public DrawingData()
            {
                mold = new Point(0, 0);
                mcur = new Point(0, 0);
                randValue = String.Empty;
            }
 
            public DrawingData(Point old, Point cur, string rand)
            {
                mold = old;
                mcur = cur;
                randValue = rand;
            }
            public Point old
            {
                get
                {
                    return mold;
                }
                set
                {
                    mold = value;
                }
            }
            public Point cur
            {
                get
                {
                    return mcur;
                }
                set
                {
                    mcur = value;
                }
            }
            public sting Rand
            {
                get
                {
                    return randValue;
                }
                set
                {
                    randValue = value;
                }
         }
    }
