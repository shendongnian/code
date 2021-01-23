     try
                    {
                    StringBuilder resultScript = new StringBuilder(string.Empty);
                    StringBuilder resultScript1 = new StringBuilder(string.Empty);
                    var connStr = @"Data Source=.;Initial Catalog=MatrixEPOS;Integrated Security=True";
                    var tables = new[] { "tblProductName", "tblProductSize", "tblProductType", "tblcheck", "tblcheckdetails", "tblSubProduct", "tblMeals", "tblMealDetails",
                    "tblMealSizes","tblToppings","tblToppings1","tblToppingsSize","tblDressingSize"};
                    ScriptingOptions scriptOptions = new ScriptingOptions();
                    Server srv1 = new Server(".");
                    Database db1 = srv1.Databases["MatrixEPOS"];
                    StringBuilder sb = new StringBuilder();
                    Urn[] ur;
                    resultScript.AppendLine("Use MatrixEPOS");
                    resultScript.AppendLine("GO");
                    for(int i = 0; i < tables.Length; i++)
                        {
    
                        //  Table tbl = db1.Tables[tables[i]];
                        Scripter scr = new Scripter(srv1);
    
                        foreach(Table table in db1.Tables)
                            {
                            if(table.Name == tables[i].ToString())
                                {
                                // Only include lookup tables
                                if(table.ForeignKeys.Count == 0)
                                    {
                                    ScriptingOptions options = new ScriptingOptions();
                                    options.DriAll = false;
                                    options.ScriptSchema = false;
                                    options.ScriptData = true;
                                    scr.Options = options;
    
                                    // Add script to file content 
                                    foreach(string scriptLine in scr.EnumScript(new Urn[] { table.Urn }))
                                        {
                                        string line = scriptLine;
                                        line = line.Replace("SET ANSI_NULLS ON", string.Empty);
                                        line = line.Replace("SET QUOTED_IDENTIFIER ON", string.Empty);
                                        line = line.Replace("SET ANSI_NULLS OFF", string.Empty);
                                        line = line.Replace("SET QUOTED_IDENTIFIER OFF", string.Empty);
                                        resultScript.AppendLine(line.Trim());
                                        }
                                    //resultScript1.AppendLine(table.Name);
                                    //ur = table.Urn;
                                    }
                                }
                            else { }
                            }
                        }
                    string name12 = resultScript1 + ".sql";
                    string fileName = string.Format("{0}.sql", "abc");
                    File.WriteAllText(Path.Combine("G:\\", fileName), resultScript.ToString());
                    }
                catch(Exception err)
                    {
                    Console.WriteLine(err.Message);
                    }
