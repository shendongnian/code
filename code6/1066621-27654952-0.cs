    using System.Data.Odbc;
    
    OdbcConnection con = new OdbcConnection("<connectionstring>");
    
    OdbcCommand com = new OdbcCommand("select * from TableX",con);
    
    OdbcDataAdapter da = new OdbcDataAdapter(com);
    DataSet ds = new DataSet();
    
    da.Fill(ds,"New");
    
    DataGrid dg = new DataGrid();
    dg.DataSource = ds.Tables["New"];
