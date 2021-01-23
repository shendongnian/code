    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            DataTable dataTable = new DataTable();
            using (MemoryStream mStream = new MemoryStream(fileContents))
            {
                using (var excelPackage = new ExcelPackage(mStream))
                {
                    ExcelWorksheet firstSheet = excelPackage.Workbook.Worksheets.First();
                    var endAddress = firstSheet.Dimension.End;
                    dataTable.TableName = firstSheet.Name;
                    ExcelRange headerRange = firstSheet.Cells[1, 1, 1,endAddress.Column ];
                    //Add columns using headers
                    foreach (var cell in headerRange)
                    {
                        dataTable.Columns.Add(cell.Value.ToString()); //You can hardcode whatever type you need to here
                    }
                    //Add Data:
                    for (int rowIdx = 2; rowIdx <= endAddress.Row; rowIdx++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int colIdx = 1; colIdx <= endAddress.Column; colIdx++)
                        {
                            dataRow[colIdx - 1] = firstSheet.Cells[rowIdx, colIdx].Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            //Now Do whatever you want with your DataTable:
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
