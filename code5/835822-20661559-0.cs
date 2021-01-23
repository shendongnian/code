    public partial class FlatCheckBox : Label
    {
        public bool Checked { get; set; }
        public FlatCheckBox()
        {
            InitializeComponent();
            Checked = false;
        }
        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (!DesignMode)
            {
                pevent.Graphics.Clear(Color.White);
                var bigRectangle = new Rectangle(pevent.ClipRectangle.X, pevent.ClipRectangle.Y,
                                                 pevent.ClipRectangle.Width, pevent.ClipRectangle.Height);
                var smallRectangle = new Rectangle(pevent.ClipRectangle.X + 1, pevent.ClipRectangle.Y + 1,
                                                   pevent.ClipRectangle.Width - 2, pevent.ClipRectangle.Height - 2);
                var b = new SolidBrush(UllinkColors.NEWBLUE);
                var b2 = new SolidBrush(Color.White);
                pevent.Graphics.FillRectangle(b, bigRectangle);
                pevent.Graphics.FillRectangle(b2, smallRectangle);
                if (Checked)
                {
                    pevent.Graphics.DrawImage(Resources.flatCheckedBox, new Point(3, 3));
                }
            }
        }
    }
