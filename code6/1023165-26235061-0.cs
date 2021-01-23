    using System;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.R) ||
                keyData == (Keys.Control | Keys.L) ||
                keyData == (Keys.Control | Keys.E) ||
                keyData == (Keys.Control | Keys.J)) return false;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
