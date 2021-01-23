    public partial class MultiColorLabel : Label
    {
        public MultiColorLabel()
        {
            InitializeComponent();
        }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            e.Graphics.DrawString("Match between ", this.Font, Brushes.Black, 0, 0);
            var sz = g.MeasureString("Match between ", this.Font).Width;
            using (SolidBrush sb = new SolidBrush(Color1))
                e.Graphics.DrawString(Text1, this.Font, sb, sz, 0);
            sz += g.MeasureString(Text1, this.Font).Width;
            e.Graphics.DrawString(" and ", this.Font, Brushes.Black, sz, 0);
            sz += g.MeasureString(" and ", this.Font).Width;
            using (SolidBrush sb = new SolidBrush(Color2))
                e.Graphics.DrawString(Text2, this.Font, sb, sz, 0);
            sz += g.MeasureString(Text2, this.Font).Width;
            e.Graphics.DrawString(" at ", this.Font, Brushes.Black, sz, 0);
            sz += g.MeasureString(" at ", this.Font).Width;
            using (SolidBrush sb = new SolidBrush(Color3))
                e.Graphics.DrawString(Text3, this.Font, sb, sz, 0);
        }
    }
