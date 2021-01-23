    public class CustomWizard : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // Second condition is to keep tab pages visible in design mode
            if (m.Msg == 0x1328 && !DesignMode)
            {
                m.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Tab)
                return;
            base.OnKeyDown(e);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
