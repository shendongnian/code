    public class BlackButton : Button
    {
        #region #Private Members
        private bool m_BasePaint = false;
        #endregion #Private Members
        #region #Ctor
        public BlackButton() : base()
        {
            base.ForeColor = Color.White;
            base.BackColor = Color.Black;
            this.DisabledForeColor = Color.FromArgb(0x6D, 0x6D, 0x6D);
        }
        #endregion #Ctor
        #region #Public Interface
        public Color DisabledForeColor
        {
            get;
            set;
        }
        #endregion #Public Interface
        #region #Overrides
        public override string Text
        {
            get
            {
                if (m_BasePaint)
                    return "";
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            m_BasePaint = true;
            base.OnPaint(pevent);
            m_BasePaint = false;
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak; 
            TextRenderer.DrawText(pevent.Graphics, 
                Text, 
                base.Font, 
                ClientRectangle, 
                base.Enabled ? base.ForeColor : this.DisabledForeColor, 
                flags);
        }
        #endregion #Overrides
    }
