    static void Main(string[] args)
            {
                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(new DataColumn("Name"));
                dt.Columns.Add(new DataColumn("Description"));
                DataRow dr = dt.NewRow();
                dr["Name"] = "AB";
                dr["Description"] = "ABC";
                dt.Rows.Add(dr);
                DataRow dr1 = dt.NewRow();
                dr1["Name"] = "AB";
                dr1["Description"] = "ABCD";
                dt.Rows.Add(dr1);
                DataRow dr2 = dt.NewRow();
                dr2["Name"] = "CD";
                dr2["Description"] = "ABCD";
                dt.Rows.Add(dr2);
                DataRow dr3 = dt.NewRow();
                dr3["Name"] = "AB";
                dr3["Description"] = "ABCDF";
                dt.Rows.Add(dr3);
                DataRow dr4 = dt.NewRow();
                dr4["Name"] = "BC";
                dr4["Description"] = "ABCD";
                dt.Rows.Add(dr4);
                DataRow dr5 = dt.NewRow();
                dr5["Name"] = "BC";
                dr5["Description"] = "ABCDF";
                dt.Rows.Add(dr5);
    
                StringBuilder sb = new StringBuilder();
                
                var grouped = from table in dt.AsEnumerable()
                                group table by new { DescriptionCol = table["Description"] } into groupby
                                select new
                              {
                                  Value = groupby.Key,
                                  ColumnValues = groupby
                              };
                
                foreach (var key in grouped)
                {
                    Console.WriteLine(key.Value.DescriptionCol);
                    Console.WriteLine("---------------------------");
                    int i = 1;
                    foreach (var columnValue in key.ColumnValues)
                    {
                        string comma = " , ";
    				    string and = " and ";
                            
                        if (i > 1 && i < key.ColumnValues.Count())
    					{
    						sb.Append(comma);
    					}
                        else if (i > 1 && i == key.ColumnValues.Count())
    					{
    						sb.Append(and);
    					}
    
                        sb.Append(columnValue["Name"].ToString());
                        i++;
                    }
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
