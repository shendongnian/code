	//Get entire rows or columns as collection and then print by casting
	using (var package = new ExcelPackage(existingFile))
	{
		ExcelWorkbook workBook = package.Workbook;
		if (workBook != null)
		{
			if (workBook.Worksheets.Count <= 0) 
				return;
			ExcelWorksheet currentWorksheet = workBook.Worksheets.First();
			var lastrow = currentWorksheet.Dimension.End.Row;
			var lastcol = currentWorksheet.Dimension.End.Column;
			//get the row of column headers which are strings
			object asd = new object();
			asd = currentWorksheet.Cells[1, 1, 1, lastcol].Value;
			object[,] cellObjects = (object[,])asd;
			List<string> stringList = cellObjects.Cast<string>().ToList();
			Console.WriteLine(stringList[0]);
			Console.WriteLine(stringList[1]);
			Console.WriteLine(stringList[2]);
			Console.WriteLine(stringList[3]);
			//Get Col3 which are doubles
			asd = currentWorksheet.Cells[2, 3, lastrow, 3].Value;
			cellObjects = (object[,])asd;
			List<double> doubleList = cellObjects.Cast<double>().ToList();
			Console.WriteLine(doubleList[0]);
			Console.WriteLine(doubleList[1]);
			Console.WriteLine(doubleList[2]);
			Console.WriteLine(doubleList[3]);
			Console.WriteLine(doubleList[4]);
			Console.WriteLine(doubleList[5]);
			Console.WriteLine(doubleList[6]);
			Console.WriteLine(doubleList[7]);
			Console.WriteLine(doubleList[8]);
		}
	}
