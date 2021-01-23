    public FileResult Export([DataSourceRequest]DataSourceRequest request)
    {
    //Count pages to use as iterator when adding to list
    var pages = db.Products.ToDataSourceResult(request).Total/request.PageSize;
    //Get the data representing the current grid state - page, sort and filter
    //IEnumerable products = db.Products.ToDataSourceResult(request).Data;
    //Get the data representing the current grid state - page, sort and filter
    var products = new List<Product>();
    //To ensure all pages get fetched from db
    for (int i = 1; i < pages + 1; i++)
    {
        request.Page = i;
        IEnumerable prod = db.Products.ToDataSourceResult(request).Data;
        products.AddRange(prod.Cast<Product>().ToList());
    }
			
	//Create new Excel workbook
	var workbook = new HSSFWorkbook();
	//Create new Excel sheet
	var sheet = workbook.CreateSheet();
	//(Optional) set the width of the columns
	sheet.SetColumnWidth(0, 10 * 256);
	sheet.SetColumnWidth(1, 50 * 256);
	sheet.SetColumnWidth(2, 50 * 256);
	sheet.SetColumnWidth(3, 50 * 256);
	//Create a header row
	var headerRow = sheet.CreateRow(0);
	//Set the column names in the header row
	headerRow.CreateCell(0).SetCellValue("Product ID");
	headerRow.CreateCell(1).SetCellValue("Product Name");
	headerRow.CreateCell(2).SetCellValue("Unit Price");
	headerRow.CreateCell(3).SetCellValue("Quantity Per Unit");
	//(Optional) freeze the header row so it is not scrolled
	sheet.CreateFreezePane(0, 1, 0, 1);
	int rowNumber = 1;
	//Populate the sheet with values from the grid data
	foreach (Product product in products)
	{
		//Create a new row
		var row = sheet.CreateRow(rowNumber++);
		//Set values for the cells
		row.CreateCell(0).SetCellValue(product.ProductID);
		row.CreateCell(1).SetCellValue(product.ProductName);
		row.CreateCell(2).SetCellValue(product.UnitPrice.ToString());
		row.CreateCell(3).SetCellValue(product.QuantityPerUnit.ToString());
	}
	//Write the workbook to a memory stream
	MemoryStream output = new MemoryStream();
	workbook.Write(output);
	//Return the result to the end user
	return File(output.ToArray(),   //The binary data of the XLS file
		"application/vnd.ms-excel", //MIME type of Excel files
		"GridExcelExport.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
    }
