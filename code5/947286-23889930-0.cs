    using System;
    using System.Windows.Forms;
    
    class MyListBox : ListBox {
        protected override void WndProc(ref Message m) {
            // Intercept WM_CONTEXTMENU
            if (m.Msg != 0x7b) base.WndProc(ref m);
        }
    }
