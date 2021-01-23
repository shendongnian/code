        public class TransparentLabel : RichTextBox
        {
            public TransparentLabel()
            {
                this.SetStyle(ControlStyles.Opaque, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
                this.TextChanged += TransparentLabel_TextChanged;
                this.VScroll += TransparentLabel_TextChanged;
                this.HScroll += TransparentLabel_TextChanged;
            }
    
            void TransparentLabel_TextChanged(object sender, System.EventArgs e)
            {
                this.ForceRefresh();
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams parms = base.CreateParams;
                    parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                    return parms;
                }
            }
            public void ForceRefresh()
            {
                this.UpdateStyles();
            }
        }
