    class NewDataGridView : System.Windows.Forms.DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            (FindForm() as Form1).DataGridViewKeyDown((DataGridView)this, keyData);
            //return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }
    }
