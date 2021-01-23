        private void GetDataTabletFromCSVFile(string fileName)
        {
            DataTable dt = new DataTable();
            //dt.TableName = fileName;
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(fileName))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    //foreach (string column in colFields)
                    //{
                    //    DataColumn datecolumn = new DataColumn(column);
                    //    datecolumn.AllowDBNull = true;
                    //    dt.Columns.Add(datecolumn);
                    //}
                    dt.Columns.AddRange(new DataColumn[8] {
                        new DataColumn("Symbol", typeof(string)),
                    new DataColumn("ISIN", typeof(string)),
                    new DataColumn("Company", typeof(string)),
                    new DataColumn("FirstListingDate", typeof(string)),
                    new DataColumn("FaceValue", typeof(string)),
                    new DataColumn("PaidUpValue", typeof(string)),
                    new DataColumn("MarketLot",typeof(string)),
                    new DataColumn("industry",typeof(string))
                    });
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        dt.Rows.Add(fieldData);
                    }
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))
                        .AddJsonFile("appsettings.json");
                    var configuration = builder.Build();
                    string DBconnection = configuration.GetSection("ConnectionString").Value;
                    using (SqlConnection dbConnection = new SqlConnection(DBconnection))
                    {
                        dbConnection.Open();
                        using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                        {
                            s.DestinationTableName = "Static.dbo.Securitiesinfo";
                            foreach (var column in dt.Columns)
                                s.ColumnMappings.Add(column.ToString(), column.ToString());
                            s.WriteToServer(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
