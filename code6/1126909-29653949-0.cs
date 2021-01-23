    protected void Csv_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString))
            {
                con.Open();
    //stored procs are easier to modify than query strings
                    using (SqlCommand cmd = new SqlCommand("csvProc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                // build csv as comma sep string
                                string csv = string.Empty;
    
                                foreach(DataColumn col in dt.Columns)
                                {
                                    // header row for csv
                                    csv += col.ColumnName + ',';
                                }
                                // new line
                                csv += "\r\n";
    
                                foreach(DataRow row in dt.Rows)
                                {
                                    foreach(DataColumn col in dt.Columns)
                                    {
                                        // add the data rows
                                        csv += row[col.ColumnName].ToString().Replace(",", ";") + ',';
                                    }
                                    csv += "\r\n";
                                }
    
                                // download the csv file
                                Response.Clear();
                                Response.Buffer = true;
                                Response.AddHeader("content-disposition", "attachment;filename=TestList.csv");
                                Response.Charset = "";
                                Response.ContentType = "application/text";
                                Response.Output.Write(csv);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }
            }
