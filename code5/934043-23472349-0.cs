    public class XForm : Form
    {
        #region Default value overrides
        [DefaultValue(FormStartPosition.Manual)]
        public new FormStartPosition StartPosition
        {
            get { return base.StartPosition; }
            set { base.StartPosition = value; }
        }
        [DefaultValue(FormBorderStyle.None)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }
        [DefaultValue(false)]
        public new bool ShowInTaskbar
        {
            get { return base.ShowInTaskbar; }
            set { base.ShowInTaskbar = value; }
        }
        [DefaultValue(typeof(Color), "LavenderBlush")]
        public new Color TransparencyKey
        {
            get { return base.TransparencyKey; }
            set { base.TransparencyKey = value; }
        }
        [DefaultValue(typeof(Color), "LavenderBlush")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        #endregion
        public XForm()
            : base()
        {
            // set user paint style
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // override
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TransparencyKey = BackColor = Color.LavenderBlush;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // do nothing
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // half opaque background
            using (HatchBrush brush = new HatchBrush(HatchStyle.Percent50, this.TransparencyKey))
                e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }
