    this._dsTest = new DsTest();    
    //Removing/Adding the first datatable
    this._dsTest.Tables.Remove(this._dsTest.TestTable);
    this._dsTest.AcceptChanges();
    this._dsTest.Tables.Add(new DsTest.TestTableDataTable());
    this._dsTest.AcceptChanges();
