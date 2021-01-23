    // V.Batch
    bt.batchNum = Convert.ToInt32((metroGrid2.CurrentCell.Value).ToString());
    V.BatchEdit bEdit = new V.BatchEdit(bt);
    this.Hide(); 
    bEdit.Show();
    // V.BatchEdit
    private M.Batch bt;
    private DataSet a;
    public BatchEdit(M.Batch batch)
    {
      this.bt = batch;
      this.a = this.bt.getBatch(bt.batchNum)
    
      // Rest of your code here.
    }
