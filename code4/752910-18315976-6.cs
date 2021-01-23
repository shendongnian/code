    public abstract class DrawableItemBase : Epl2CommandBase, IDrawableCommand
    {
        protected DrawableItemBase()
        {
            Location = new Point();
        }
        protected DrawableItemBase(Point location)
        {
            Location = location;
        }
        protected DrawableItemBase(int x, int y)
        {
            Location = new Point();
            X = x;
            Y = y;
        }
        private Point _Location;
        [XmlIgnore]
        public virtual Point Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        [XmlIgnore]
        public int X
        {
            get { return _Location.X; }
            set { _Location.X = value; }
        }
        [XmlIgnore]
        public int Y
        {
            get { return _Location.Y; }
            set { _Location.Y = value; }
        }
        abstract public void Paint(Graphics g, Image buffer);
    }
