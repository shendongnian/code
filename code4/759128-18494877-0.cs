    public class CustomGrid : DataGridView {            
            protected override bool ProcessDialogKey(Keys keyData) {
                if (keyData == Keys.Enter) {    
                    EndEdit();
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
    }
