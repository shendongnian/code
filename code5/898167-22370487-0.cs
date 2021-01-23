    public class CustomWizard : TabControl
    {
        /// <summary>
        /// This method traps windows message and hides other tabs in the tab control.
        /// Message trapped: TCM_ADJUSTRECT
        /// </summary>
        /// <param name="m">Reference to Windows message</param>
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
        /// <summary>
        /// This method traps the press to stop users from selecting tab page via keyboard
        /// </summary>
        /// <param name="ke">Event details</param>
        protected override void OnKeyDown(KeyEventArgs ke)
        {
            if (ke.Control && ke.KeyCode == Keys.Tab)
                return;
            base.OnKeyDown(ke);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
