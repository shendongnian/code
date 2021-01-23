    using System;
    using System.Windows.Forms;
    
    class MyDataGridView : DataGridView {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.C)) {
                // Do stuff
                //..
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
