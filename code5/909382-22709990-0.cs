    private static List<string> getHeader(string fileName)
                    {
                        string fullpath = @ImportPath + "\\" + fileName;
                        List<string> header = new List<string>();
                        var reader = new StreamReader(File.OpenRead(fullpath));
            
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');
            
                            foreach (var spalte in values)
                            {
                                header.Add(spalte);
                            }
                            reader.Close();
                            return header;
                        }
                        return null;
                    }
        
        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader, string csvSelection)
                {
                    string header= isFirstRowHeader ? "Yes" : "No";
        
                    string pathOnly = Path.GetDirectoryName(path);
                    string fileName = Path.GetFileName(path);
                    List<string> headerList = getHeader(fileName);
                    string sql = @"SELECT " + "*" + " FROM [" + fileName + "]";
                    //string sql = @"SELECT * FROM [" +  fileName  + "];";
        
                    using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + ";Extended Properties=\"Text;HDR=" + headerList + ";FMT=Delimited(;)\""))
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Locale = CultureInfo.CurrentCulture;
                        foreach (var item in headerList)
                        {
                            dataTable.Columns.Add(item);
                        }
            
                        adapter.Fill(dataTable);
                        writeSchema(dataTable.Columns, pathOnly, fileName);
                        return dataTable;
                    }
        
                }
