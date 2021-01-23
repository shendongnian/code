    public class ChromeCheckListBox : ChromeContainerControl
    {
        [Description("Determines what corner(s) will be rounded.")]
        public Utilities.RoundedRectangle.RectangleCorners Corners { get; set; }
        private int cornerRadius;
        [Description("Determines the radius of the the corners")]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                if (value < 1)
                    Utilities.ThrowError("The radius cannot be less than 1. If you want no radius, set Corners to None.");
                else
                    cornerRadius = value;
            }
        }
        [Description("Determines the list of ChromeRadioButton controls that are displayed.")]
        private ChromeCheckBox[] items;
        public ChromeCheckBox[] Items
        {
            get { return items; }
            set
            {
                items = value;
                Controls.Clear();
                Controls.AddRange(items);
            }
        }
        public ChromeCheckListBox()
        {
            this.AutoScroll = true;
            this.Corners = Utilities.RoundedRectangle.RectangleCorners.All;
            this.CornerRadius = 1;
            this.Items = new ChromeCheckBox[0];
            this.Size = new Size(100, 100);
            
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i == 0)
                    Items[i].Location = new Point(2 + Padding.Left, 2 + Padding.Top);
                else
                    Items[i].Location = new Point(2 + Padding.Left, Items[i - 1].Location.Y + Size.Ceiling(this.CreateGraphics().MeasureString(Items[i - 1].Text, Items[i - 1].Font)).Height);
            }
            base.OnControlAdded(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            canvas.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle region = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath path = Utilities.RoundedRectangle.Create(region, CornerRadius, Corners);
            canvas.FillPath(new LinearGradientBrush(region, fillColors[0], fillColors[1], 90), path);
            canvas.DrawPath(new Pen(borderColor), path);
        }
