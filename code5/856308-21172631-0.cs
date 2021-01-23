    public struct RectangleF
    {
        float w = 0;
        float h = 0;
        float x = 0;
        float y = 0;
        public float Height
        {
            get { return h; }
            set { h = value; }
        }
        //put Width, X, and Y properties here
        public RectangleF(float X, float Y, float width, float height)
        {
            w = width;
            h = height;
            x = X;
            y = Y;
        }
        public bool Intersects(Rectangle refRectangle)
        {
            Rectangle rec = new Rectangle((int)x, (int)y, (int)w, (int)h);
            if (rec.Intersects(refRectangle)) return true;
            else return false;
        }
    }
