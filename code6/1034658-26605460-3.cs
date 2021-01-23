    private void FillData()
    {
            string sql = "SELECT Id, Code, Desc FROM myTable";
            dt = fillMyDataTable(sql);
            DataRowChangeEventArgs args = new DataRowChangeEventArgs (dt.Rows, dt.RowState);
            dt_RowChanged(this, args);
    
    }
