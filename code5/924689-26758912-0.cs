    FileInfo file = new FileInfo(path);
			using (var package = new ExcelPackage(file))
			{
				ExcelWorkbook workBook = package.Workbook;
				ExcelWorksheet currentWorksheet = workBook.Worksheets.SingleOrDefault(w =>  w.Name == "sheet1");
				int totalRows = currentWorksheet.Dimension.End.Row;
				int totalCols = currentWorksheet.Dimension.End.Column;
				for (int i = 2; i <= totalRows; i++)
				{					
					try
					{
						currentWorksheet.Cells[i, 1].Value = "AAA";
						
					}
					catch (Exception ex)
					{
						_logger.Error(String.Format("Error: failed editing  excel. See details: {0}", ex));
						return;
					}
				}
				
				package.Save();
