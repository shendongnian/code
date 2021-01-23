    public delegate void InvokeDelegate();
    
    public void MyDelegate()
    {
    	dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        table.AcceptChanges();
    }
    
    //CurrentCellDirtyStateChanged Event
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
    	if (dataGridView1.IsCurrentCellDirty == true && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
    	{
    		BeginInvoke(new InvokeDelegate(MyDelegate));
    	}
    }
