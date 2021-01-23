	[TestMethod]
	public void SQL_Reader_Test()
	{
		var Template = new FileInfo(@"c:\temp\temp.xlsx");
		if (Template.Exists)
			Template.Delete();
		var xlPackage = new ExcelPackage(Template);
		//var wsCards = xlPackage.Workbook.Worksheets[4];
		var wsCards = xlPackage.Workbook.Worksheets.Add("Cards");
		//const string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\temp\northwind.mdb;Persist Security Info=False;";
		const string constring = @"Provider=SQLNCLI11;Data Source=MYMACHINENAME\SQLEXPRESS;Initial Catalog=AdventureWorks;UID=AdventureWorks; Pwd=AdventureWorks";
		using (var CON = new OleDbConnection(constring))
		{
			CON.Open();
			//string command = "SELECT * FROM dbo_serial_cards WHERE type <> 'EXT' AND LEFT([device_tag], 2) <> '!!'";
			const string command = "SELECT * FROM Person.Address";
			var cmd = new OleDbCommand(command, CON);
			var reader = cmd.ExecuteReader();
			int row = 1;
			while (reader.Read())
			{
				row++;
				//for (int col = 1; col <= 16; col++)
				for (int col = 1; col <= reader.FieldCount; col++)
				{
					wsCards.Cells[row, col].Value = reader.GetValue(col - 1);
				}
			}
			xlPackage.SaveAs(Template);
			xlPackage.Dispose();
		}
	} 
