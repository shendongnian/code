	[TestMethod]
	public void Increae_Row_Test()
	{
		//http://stackoverflow.com/questions/28340229/formular1c1-increasing-row-value-epplus
		//Throw in some data
		var dtDadosPop = new DataTable("tblData");
		dtDadosPop.Columns.Add(new DataColumn("Col1"));
		dtDadosPop.Columns.Add(new DataColumn("Col2"));
		for (var i = 0; i < 11; i++)
		{
			var row = dtDadosPop.NewRow();
			row["Col1"] = "Col1 Row" + i;
			row["Col2"] = "Col2 Row" + i;
			dtDadosPop.Rows.Add(row);
		}
		//create the excel file
		var excelfile = new FileInfo(@"c:\temp\temp.xlsx");
		if (excelfile.Exists)
			excelfile.Delete();
		//Use an file in memory for the package "p"
		using (var p = new ExcelPackage())
		using (var package = new ExcelPackage(excelfile))
		{
			ExcelWorkbook workBook = package.Workbook;
			if (workBook != null)
			{
				//add the parts referenced by OP code
				workBook.Worksheets.Add("% Mean Removal");
				var dataws = workBook.Worksheets.Add("Dados Projeto");
				dataws.Cells.LoadFromDataTable(dtDadosPop, true);
				p.Workbook.Worksheets.Add("Dados Projeto", dataws);
				//OP code
				if (workBook.Worksheets.Count > 0)
				{
					ExcelWorksheet RMWorksheet = workBook.Worksheets["% Mean Removal"];
					//RMWorksheet.Cells[3, 2, (dtDadosPop.Rows.Count + 2), 2].FormulaR1C1 = "'Dados Projeto'!R[-1]C";
					for (var i = 1; i <= dtDadosPop.Rows.Count; i++)
					{
						RMWorksheet.Cells[i + 2, 2].FormulaR1C1 = "'Dados Projeto'!R[-1]C";
					}
					p.Workbook.Worksheets.Add("% Mean Removal", RMWorksheet);
				}
			}
			package.SaveAs(excelfile);
		}
	}
