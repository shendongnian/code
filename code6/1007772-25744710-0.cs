    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class UnmanagedDialogParent : NativeWindow {
        private Form dialog;
        public DialogResult ShowDialog(IntPtr parent, Form dlg) {
            if (!IsWindow(parent)) throw new ArgumentException("Parent is not a valid window");
            dialog = dlg;
            this.AssignHandle(parent);
            DialogResult retval = DialogResult.Cancel;
            try {
                retval = dlg.ShowDialog(this);
            }
            finally {
                this.ReleaseHandle();
            }
            return retval;
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_DESTROY) dialog.Close();
            base.WndProc(ref m);
        }
        // Pinvoke:
        private const int WM_DESTROY = 2;
        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);
    }
