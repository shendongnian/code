    public class MyCheckBox : CheckBox
    {
        public bool ReadOnly {get; set;}
        private bool m_fInEvent;
        protected override void  OnCheckedChanged(EventArgs e)
        {
            if (ReadOnly) {
                if (!m_fInEvent) {
                    try {
                        // Prevent infinite recursion
                        m_fInEvent = true;
                        this.Checked = !this.Checked;
                    } finally {
                        m_fInEvent = false;
                    } 
                }
            }
            base.OnCheckedChanged(e);
        }
    }
