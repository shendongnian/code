    public static void ExportGridView(string fileName, GridView gv, Label header, Label date)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        gv.AllowPaging = false;
                        //  Create a table to contain the grid
                        Table table = new Table();
                        //  include the gridline settings
                        table.GridLines = gv.GridLines;
                        gv.Style["font-family"] = "Tahoma";
                        //  add the header row to the table
                        if (gv.HeaderRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                            gv.HeaderRow.BackColor = System.Drawing.Color.Lavender;
                            gv.HeaderRow.ForeColor = System.Drawing.Color.Green;
                            table.Rows.Add(gv.HeaderRow);
                        }
                        //  add each of the data rows to the table
                        foreach (GridViewRow row in gv.Rows)
                        {
                            GridViewExportUtil.PrepareControlForExport(row);
                            table.Rows.Add(row);
                        }
                        //  add the footer row to the table
                        if (gv.FooterRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                            table.Rows.Add(gv.FooterRow);
                        }
                        htw.WriteLine("<br>");
                        // htw.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                        if (header.Text != null)
                        {
                            header.Font.Size = 15;
                            header.Font.Bold = true;
                            header.ForeColor = System.Drawing.Color.Blue;
                            header.RenderControl(htw);
                        }
                        htw.WriteLine("</p>");
                        //  render the table into the htmlwriter
                        table.RenderControl(htw);
                        htw.WriteLine("<br>");
                        htw.WriteLine("Report taken on :", System.Drawing.FontStyle.Bold);
                        if (date.Text != null)
                        {
                            date.ForeColor = System.Drawing.Color.Blue;
                            date.RenderControl(htw);
                        }
                        //  render the htmlwriter into the response
                        HttpContext.Current.Response.Write(sw.ToString());
                        HttpContext.Current.Response.End();
                    }
                }
            }
