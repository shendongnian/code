    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty == true && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
        {
            // use BeginInvoke with (MethodInvoker) to run the code after the event is finished
            BeginInvoke((MethodInvoker)delegate
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                table.AcceptChanges();
            });
        }
    }
