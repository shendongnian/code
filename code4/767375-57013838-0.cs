    class BlackButton : Button
    {
        #region #Private Members
        private string m_Text = "";
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
                return m_Text;
            }
            set
            {
                m_Text = value;
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
                pevent.ClipRectangle, 
                base.Enabled ? base.ForeColor : this.DisabledForeColor, 
                flags);
        }
        #endregion #Overrides
    }
