    using (System.IO.StreamReader file = new System.IO.StreamReader(Server.MapPath(filepath)))
                            {
                                //Csv reader reads the stream
                                CsvReader csvread = new CsvReader(file);
                                while (csvread.Read())
                                {
                                    int count = csvread.FieldHeaders.Count();
                                    if (count == 55)
                                    {
                                        DataRow dr = myExcelTable.NewRow();
                                        if (csvread.GetField<string>("FirstName") != null)
                                        {
                                            dr["FirstName"] = csvread.GetField<string>("FirstName"); ;
                                        }
                                        else
                                        {
                                            dr["FirstName"] = "";
                                        }
    
                                        if (csvread.GetField<string>("LastName") != null)
                                        {
                                            dr["LastName"] = csvread.GetField<string>("LastName"); ;
                                        }
                                        else
                                        {
                                            dr["LastName"] = "";
                                        }
                                    }
                                    else
                                    {
                                        lblMessage.Visible = true;
                                        lblMessage.Text = "Columns are not in specified format.";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                        return;
                                    }
                                }
                                }
