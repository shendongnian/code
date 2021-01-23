    DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns.Add("Column2");
                dt.Columns.Add("Column3");
                dt.Rows.Add(new string[] {"Some value1", "Some value2", "Some value3" });
                dt.AsEnumerable().ToList().ForEach(x =>
                    {
                        if (x["Column1"] == "Some value1")
    	                {
                            dt1.ImportRow(x);
                            dt.Rows.Remove(x);
    	                }
                    });
