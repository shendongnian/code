    public partial class DisabledTextBox : Control
    {
        public DisabledTextBox()
        {
            InitializeComponent();
            DoubleBuffered = true; // To avoid flickering
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(SystemColors.Window); // White background
            pe.Graphics.DrawRectangle(SystemPens.ActiveBorder, new Rectangle(0, 0, Width - 1, Height - 1)); // Gray border
            pe.Graphics.DrawString(Text, Font, SystemBrushes.WindowText, 1, 3); // Our text
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate(); // We want to repaint our control when text changes
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = Font.Height + 7; // This limit the height of our control so it will beahave like a normal TextBox
        }
    }
