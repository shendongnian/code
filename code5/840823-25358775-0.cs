    [HttpPost]
        public DataTable PostValues(HttpPostedFileBase file)
        {
           ISheet sheet;
           string filename = Path.GetFileName(Server.MapPath(file.FileName));
           var fileExt = Path.GetExtension(filename);
           if (fileExt == ".xls")
             {
              HSSFWorkbook hssfwb = new HSSFWorkbook(file.InputStream); 
              sheet = hssfwb.GetSheetAt(0);
              }
            else             
              {
              XSSFWorkbook hssfwb = new XSSFWorkbook(file.InputStream); 
              sheet = hssfwb.GetSheetAt(0);
              }
           DataTable table = new DataTable();
           IRow headerRow = sheet.GetRow(0);
           int cellCount = headerRow.LastCellNum;
           for (int i = headerRow.FirstCellNum; i < cellCount; i++)
           {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
            }
           int rowCount = sheet.LastRowNum;
           for (int i = (sheet.FirstRowNum); i < sheet.LastRowNum; i++)
            {
             IRow row = sheet.GetRow(i);
            DataRow dataRow = table.NewRow();
             for (int j = row.FirstCellNum; j < cellCount; j++)
            {
              if (row.GetCell(j) != null)
                {
                dataRow[j] = row.GetCell(j).ToString();
                }
            }
        table.Rows.Add(dataRow);
                            }
          return table;
            }
