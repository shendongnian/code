    private SqlCeDataAdapter dataAdapterSqlCe;
    private SqlCeConnection connectionSqlCe;
    private DataSet dataSet;
    private DataTable dataTable;
        
    // Creating connection to SqlCE DB
    connectionSqlCe = new SqlCeConnection(ConnectionString);
    connectionSqlCe.Open();
    
    // create new DataAdapter based on connection obj and SelectQuery
    dataAdapterSqlCe = new SqlCeDataAdapter();
    dataAdapterSqlCe.SelectCommand = new SqlCeCommand(SelectQuery, connectionSqlCe);
    
    // create DataSet
    dataSet = new DataSet();
    
    // use DataAdapter to Fill Dataset
    dataAdapterSqlCe.Fill(dataTable);
        
    #region Binding dataGrid to dataTable
    // DataGrid binding
    dataGrid.ItemsSource = dataTable.DefaultView;
    
    // or, alternatively
     dataGrid.DataContext = dataTable;
     #endregion
    
    connectionSqlCe.Close();
