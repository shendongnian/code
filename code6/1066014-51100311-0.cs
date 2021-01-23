    using (var openFileDialog1 = new OpenFileDialog { Filter = "Excel Workbook|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var fs = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                        var reader = ExcelReaderFactory.CreateBinaryReader(fs);
                        var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true // Use first row is ColumnName here :D
                            }
                        });
                        if (dataSet.Tables.Count > 0)
                        {
                            var dtData = dataSet.Tables[0];
                            // Do Something
                        }
                    }
                }
