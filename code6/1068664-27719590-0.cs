        protected void Page_Load(object sender, EventArgs e)
        {
    string str = "Provider=Microsoft.ACE.OleDB.12.0; Data Source=C:\\Users\\Dima\\Documents\\Visual Studio 2013\\Projects\\networklab1\\bin\\weblabdb.accdb";
            OleDbConnection db = new OleDbConnection(str);
            db.Open();
            string st = "select areaName from area;";
            OleDbCommand dbc = new OleDbCommand(st, db);
            OleDbDataReader read = dbc.ExecuteReader();
    
            DropDownList1.DataSource = read;
            DropDownList1.DataTextField="ShownTextFieldFromDatabaseResults";;       
            DropDownList1.DataValueField="ValueFieldFromDatabaseResults";        
            DropDownList1.DataBind();
            read.Close();
            db.Close();
   
        }
