    public void Upload(HttpPostedFileBase file)
    {
           package.Load(file.InputStream);
        
        	var worksheet = package.Workbook.Worksheets.First();
        	var celllValue = worksheet.Cells[rowIndex, columnIndex].Value;
    }
