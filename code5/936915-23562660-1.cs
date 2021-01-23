    void Main()
    {
    	DataTable tableOld = new DataTable();
    	tableOld.Columns.Add("ID", typeof(int));
    	tableOld.Columns.Add("Name", typeof(string));
    	
    	tableOld.Rows.Add(1, "1");
    	tableOld.Rows.Add(2, "2");
    	tableOld.Rows.Add(3, "3");
    	
    	DataTable tableNew = new DataTable();
    	tableNew.Columns.Add("ID", typeof(int));
    	tableNew.Columns.Add("Name", typeof(string));
    	
    	tableNew.Rows.Add(1, "1");
    	tableNew.Rows.Add(2, "2");
    	tableNew.Rows.Add(3, "33");
    	
    	tableOld.Rows[2].ItemArray = tableNew.Rows[2].ItemArray; //update specific row of tableOld with new values
    	
    	//tableOld.Dump();
    }
