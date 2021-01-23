     using (OleDbConnection connection = new OleDbConnection(conecctionstring))
                {
                    string selectquery = "string query";
                    using (OleDbDataAdapter selectCommand = new OleDbDataAdapter(selectquery, connection))
                    {
                        DtSet1 = new DataSet();
                        selectCommand.Fill(DtSet1, "Table1");
                        var wb = new XLWorkbook();
                        var saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Excel files|*.xlsx",
                            Title = "Save an Excel File"
                        };
                        
                        wb.Worksheets.Add(DtSet1);
                        saveFileDialog.ShowDialog();
                        if (!String.IsNullOrWhiteSpace(saveFileDialog.FileName))
                        {
                            wb.SaveAs(saveFileDialog.FileName);
                            var workbook = new XLWorkbook(saveFileDialog.FileName);
                            var ws = workbook.Worksheet(1);
                            ws.Range("C2:C100").AddConditionalFormat().WhenEqualOrLessThan(DateTime.Now.ToOADate()).Fill.SetBackgroundColor(XLColor.Red);
                            ws.Range("C2:C100").AddConditionalFormat().WhenGreaterThan(DateTime.Now.ToOADate() + 6).Fill.SetBackgroundColor(XLColor.Orange);
                            workbook.SaveAs(saveFileDialog.FileName);
                       }
                    }
                }
