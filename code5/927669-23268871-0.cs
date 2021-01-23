    [System.ComponentModel.DesignerCategory("Code")]
    public class XTableLayoutPanel : TableLayoutPanel
    {
        [DefaultValue(typeof(Color), "Transparent")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        public XTableLayoutPanel()
        {
            // set user paint style
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // do nothing
        }
	}
