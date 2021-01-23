    public class MyTextBox : TextBox
    {
        public MyTextBox() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            Multiline = true;
            Width = 130;
            Height = 119;
        }
        public override sealed bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = value; }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            var newRectangle = ClientRectangle;
            newRectangle.Inflate(-10, -10);
            e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);
            Region = new System.Drawing.Region(buttonPath);
            base.OnPaintBackground(e);
        }      
    }
