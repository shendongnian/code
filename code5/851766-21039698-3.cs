    public DataTable LoadFromExcelFile(string filePath)
    {
    	String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
    	//Create Connection to Excel work book 
    	using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
    	{
    		//Create OleDbCommand to fetch data from Excel - you can query the sheet as if it were a sql table effectively
    		using (OleDbCommand cmd = new OleDbCommand("SELECT [Column1],[Column2],[Column3] from [Sheet1$]", excelConnection))
    		{
    			excelConnection.Open();
    			using (OleDbDataReader dReader = cmd.ExecuteReader())
    			{
    				DataTable myData = new DataTable();
    				myData.Load(dReader);
    				return myData;
    			}
    		}
    	}
    } 
