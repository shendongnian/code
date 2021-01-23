    public partial class frmAutoCloseDropDown : Form, IMessageFilter
    {
        int _lastMsg;
        public frmAutoCloseDropDown()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        // THIS ATTEMPT DOES NOT WORK!
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_LBUTTONDOWN = 0x0201;
            if (m.Msg!= _lastMsg) {
                _lastMsg = m.Msg;
            }
            if (m.Msg == WM_LBUTTONDOWN) {
                // You would have to do this recursively if the combo-boxes were nested inside other controls.
                foreach (ComboBox cbo in Controls.OfType<ComboBox>()) {
                    cbo.DroppedDown = false;
                }
            }
            return false;
        }
        // Note: Dispose is created inside *.Designer.cs and you have to move it manually to *.cs
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Application.RemoveMessageFilter(this);
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
