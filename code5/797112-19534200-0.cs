        public void ExportToExcel(string strFileName, DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView gv = new GridView();
                    gv.DataSource = dt;
                    gv.DataBind();
                    ExportToExcel(strFileName, gv);
                }
                else
                {
                    BindScript(this.Page, "excelError", "alert('No Data to Generate Excel !')");
                }
            }
            catch (Exception ex)
            {
                BindScript(this.Page, "excelError", "alert('Some error occured " + ex.Message + "')");
            }
        }
        private void ExportToExcel(string strFileName, GridView gv)
        {
            try
            {
                if (gv.Rows.Count > 0)
                {
                    //Page page = new Page();
                    //HtmlForm form = new HtmlForm();
                    //Response.ClearContent();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
                    //Response.ContentType = "application/excel";
                    ////System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //StringWriter sw = new StringWriter();
                    //HtmlTextWriter htw = new HtmlTextWriter(sw);
                    //form.Controls.Add(gv);
                    //page.Controls.Add(form);
                    ////form.RenderControl(htw);
                    //HttpContext.Current.Server.Execute(page, sw, true);
                    //Response.Write(sw.ToString());
                    //Response.Flush();
                    //Response.End();
                    StringWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);
                    //Get the HTML for the control.
                    gv.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
                    EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
                else
                {
                    BindScript(this.Page, "excelError", "alert('No Data to Generate Excel !')");
                }
            }
            catch (Exception ex)
            {
                BindScript(this.Page, "excelError", "alert('Some error occured " + ex.Message + "')");
            }
        }
