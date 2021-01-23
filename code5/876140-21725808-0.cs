    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private class ComboHooker : NativeWindow {
            protected override void WndProc(ref Message m) {
                if (m.Msg == 0x134) {
                    // etc...
                }
                else {
                    // Stop sub-classing on WM_NCDESTROY
                    if (m.Msg == 0x82) this.ReleaseHandle();
                    base.WndProc(ref m);
                }
            }
        }
        private void hookComboBoxes(Control.ControlCollection ctls) {
            foreach (Control ctl in ctls) {
                if (ctl.GetType() == typeof(ComboBox)) {
                    new ComboHooker().AssignHandle(ctl.Handle);
                }
                hookComboBoxes(ctl.Controls);
            }
        }
        protected override void OnLoad(EventArgs e) {
            hookComboBoxes(this.Controls);
            base.OnLoad(e);
        }
    }
