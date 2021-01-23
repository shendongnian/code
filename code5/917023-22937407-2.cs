    public void Upload(HttpPostedFileBase file)
    {
          package.Load(file.InputStream);
        
         var worksheet = package.Workbook.Worksheets.First();
         var cellValue = worksheet.Cells[rowIndex, columnIndex].Value;
         var formulaValue = worksheet.Cells[rowIndex, columnIndex].Formula;
    }
