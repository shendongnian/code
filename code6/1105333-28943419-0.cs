    public partial class DisabledTextBox : Control
    {
        public DisabledTextBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(SystemColors.Window);
            pe.Graphics.DrawRectangle(SystemPens.ActiveBorder, new Rectangle(0, 0, Width - 1, Height - 1));
            pe.Graphics.DrawString(Text, Font, SystemBrushes.WindowText, 1, 3);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = Font.Height + 7;
        }
    }
