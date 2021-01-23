    public DataRow[] Select()
    {
        Bid.Trace("<ds.DataTable.Select|API> %d#\n", this.ObjectID);
        return new Select(this, "", "", DataViewRowState.CurrentRows).SelectRows();
    }
 
