    //form level fields
            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter adapter;// = new OleDbDataAdapter();
            DataTable table = new DataTable();
            BindingSource bSource = new BindingSource();
    
    //choosing MS Access file 
            var ecgDbFile = new OpenFileDialog();
            ecgDbFile.InitialDirectory = "c:\\";
            ecgDbFile.Filter = @"MS Access files (*.mdb)|*.mdb";
            ecgDbFile.FilterIndex = 1;
            ecgDbFile.RestoreDirectory = true;
    //creating connection
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ecgDbFile.FileName;
            conn.Open();
    //A nice way how to get a list of Data base's tables
            var restrictions = new string[4];
            restrictions[3] = "Table";
            userTableList = conn.GetSchema("Tables", restrictions);
    //then loop through and you can get table names => userTableList.Rows[i][2].ToString()
    //reading the data (in the grid)
            adapter = new OleDbDataAdapter("Select * from "+TableName, conn);
            adapter.Fill(table);
            bSource.DataSource = table; //binding through bindingsource
            GridControl.DataSource = bSource; //actually it works fine if GridControl.DataSource is set to table directly as well...
    
    //choose the appropriate trigger to call for database updates
        private void GridControl_Leave(object sender, EventArgs e)
        {
            //because of this OleDbCommandBuilder TableAdapter knows how to insert/update database
            OleDbCommandBuilder command = new OleDbCommandBuilder(adapter);
            adapter.Update(table);
        }
