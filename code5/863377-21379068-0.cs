    protected void ExportToExcel(DataTable dt)
            {
                //Create a dummy GridView
                GridView GridView1 = new GridView();
                GridView1.ShowHeaderWhenEmpty = true;
                GridView1.AllowPaging = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();            
    
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
    
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                List<int> decimalModeColumnsIndexes = new List<int>();
    
                // Set the column's header with the caption of the Column in the DataTable
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    GridView1.HeaderRow.Cells[i].Text = dt.Columns[i].Caption;                
                }
    
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //Apply text style to each cell
                    if (decimalModeColumnsIndexes.Count != 0)
                    {
                        for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
                        {
                            if (decimalModeColumnsIndexes.Count(colIndex => colIndex == j) == 1)
                            {
                                GridView1.Rows[i].Cells[j].Attributes.Add("class", "decimalmode");
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[j].Attributes.Add("class", "textmode");
                            }
                        }
                    }
                    else
                    {
                        GridView1.Rows[i].Attributes.Add("class", "textmode");
                    }
    
                }
    
                String fileName = dt.TableName;
                fileName = String.Format("{0}_{1}", fileName, DateTime.UtcNow);
    
                fileName = fileName.Replace(':', '-');
                fileName = fileName.Replace(' ', '-');
    
    
                GridView1.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } .decimalmode { mso-number-format:""0\.00""; } </style>";
    
    
                HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", fileName));
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Output.Write(sw.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
    
            }
