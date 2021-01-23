     private void ExportToExcel(DataTable dt)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Sheet1.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                GridView dgGrid = new GridView();
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
    
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
    
                    dgGrid.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in dgGrid.HeaderRow.Cells)
                    {
                        cell.BackColor = dgGrid.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in dgGrid.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = dgGrid.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = dgGrid.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }
    
                    dgGrid.RenderControl(hw);
    
                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
