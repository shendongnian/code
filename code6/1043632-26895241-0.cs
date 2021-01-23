    public partial class ExtendedTextBox : UserControl
    {
        [PropertyTab("Data")]
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Set TextBox border Color")]
        public Color BorderColor { get; set; }
        [PropertyTab("Data")]
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Set TextBox Text")]
        public string Texts
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        private TextBox textBox;
        public ExtendedTextBox()
        {
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(textBox);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Size = new Size(this.Width - 3, this.Height - 2);
            textBox.Location = new Point(2, 1);
        }
    }
