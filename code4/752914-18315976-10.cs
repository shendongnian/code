    [XmlInclude(typeof(Rectangle))]
    public abstract partial class Epl2CommandBase { }
    /// <summary>
    /// Use this command to draw a box shape.
    /// </summary>
    public class Rectangle : DrawableItemBase, IEpl2GeneralFactoryProduct
    {
        #region Constructors
        public Rectangle() : base() { }
        public Rectangle(Point startingLocation, int horozontalEndPosition, int verticalEndPosition)
            : base(startingLocation)
        {
            HorizontalEndPosition = horozontalEndPosition;
            VerticalEndPosition = verticalEndPosition;
        }
        public Rectangle(int x, int y, int lineThickness, int horozontalEndPosition, int verticalEndPosition)
            : base(x, y)
        {
            LineThickness = lineThickness;
            HorizontalEndPosition = horozontalEndPosition;
            VerticalEndPosition = verticalEndPosition;
        }
        #endregion
        #region Properties
        [XmlIgnore]
        public int LineThickness { get; set; }
        [XmlIgnore]
        public int HorizontalEndPosition {get; set;}
        [XmlIgnore]
        public int VerticalEndPosition { get; set; }
        public override string CommandString
        {
            get
            {
                return String.Format("X{0},{1},{2},{3},{4}", X, Y, LineThickness, HorizontalEndPosition, VerticalEndPosition);
            }
            set
            {
                GenerateCommandFromText(value);
            }
        }
        #endregion
        #region Helpers
        private void GenerateCommandFromText(string command)
        {
            if (!command.StartsWith(GetFactoryKey()))
                throw new ArgumentException("Command must begin with " + GetFactoryKey());
            string[] commands = command.Substring(1).Split(',');
            this.X = int.Parse(commands[0]);
            this.Y = int.Parse(commands[1]);
            this.LineThickness = int.Parse(commands[2]);
            this.HorizontalEndPosition = int.Parse(commands[3]);
            this.VerticalEndPosition = int.Parse(commands[4]);
        }
        #endregion
        #region Members
        public override void Paint(Graphics g, Image buffer)
        {
            using (Pen p = new Pen(Color.Black, LineThickness))
            {
                g.DrawRectangle(p, new System.Drawing.Rectangle(X, Y, HorizontalEndPosition - X, VerticalEndPosition - Y));
            }
             
        }
        public string GetFactoryKey()
        {
            return "X";
        }
        #endregion
    }
