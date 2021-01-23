		private void Form1_Load(object sender, EventArgs e)
		{   
		   try
		   {        
				string sheetName = "Sheet1$";// Read the whole excel sheet document      
				DataTable sheetTable = loadSingleSheet(@"C:\excelFile.xls", sheetName);
				dataGridView1.DataSource = sheetTable;
		 
				string sheetNameWithRange = "Sheet1$A1:D10"; // Read excel sheet document from A1 cell to D10 cell values.
				DataTable sheetTableWithRange = loadSingleSheet(@"C:\excelFile.xls",sheetNameWithRange);
				dataGridView2.DataSource = sheetTableWithRange;
		   }
		   catch (Exception Ex)
		   {
				MessageBox.Show(Ex.Message, "");
		   }  
		}        
		 
		private OleDbConnection returnConnection(string fileName)
		{
			return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
		}
		 
		private DataTable loadSingleSheet(string fileName, string sheetName)
		{           
			DataTable sheetData = new DataTable();
			using (OleDbConnection conn = this.returnConnection(fileName))
			{
			   conn.Open();
			   // retrieve the data using data adapter
			   OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select * from [" + sheetName + "]", conn);
				sheetAdapter.Fill(sheetData);
			}                        
			return sheetData;
		}
