    protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string s = FileUpload1.FileName.Trim();
                if (s.EndsWith(".csv"))
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/data/" + s));
                    string[] readText = File.ReadAllLines(Server.MapPath("~/data/" + s));
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                   // Array.Sort(readText);
                   
                    for (int i = 0; i < readText.Length; i++)
                    {
                        if (i == 0)
                        {
                            string str = readText[0];
                            string[] header = str.Split(',');
    
                            dt.TableName = "sal";
                            foreach (string k in header)
                            {
                                dt.Columns.Add(k);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
    
                            string str1 = readText[i];
                            if (readText[i] == ",,,,")
                            {
                                break;
                            }
    
    
                            string[] rows = str1.Split(',');
                            if (dt.Columns.Count == rows.Length)
                            {
    
                                for (int z = 0; z < rows.Length; z++)
                                {
                                    if (rows[z] == "")
                                    {
                                        rows[z] = null;
    
                                    }
    
                                    dr[z] = rows[z];
                                }
                                dt.Rows.Add(dr);
                               
    
                            }
                            else
                            {
                                Label1.Text = "please select valid format";
                            }
                        }
    
    
                    }
                   
                    //Iterate through the columns of the datatable to set the data bound field dynamically.
                    ds.Merge(dt);
                    Session["tasktable"] = dt;
                    foreach (DataColumn col in dt.Columns)
                    {
                        BoundField bf = new BoundField();
    
                        bf.DataField = col.ToString();
                        bf.HeaderText = col.ColumnName;
                        if (col.ToString() == "Task")
                        {
                            bf.SortExpression = col.ToString();
                        }
                        GridView1.Columns.Add(bf);
    
                    }
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                   
    
                }
                else
                {
                    Label1.Text = "please select a only csv format";
                }
               
            }
            else
            {
                Label1.Text = "please select a file";
            }
            }
