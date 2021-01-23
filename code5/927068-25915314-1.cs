    Please try the code after HttpContext.Current.Response.Write(tw.ToString());  
    and place your HttpContext.Current.Response.End(); after the catch.
    
    #region "   Summary - Excel Upload                      "
            private void fnExcelUpload()
            {
                try
                {
                    dgDashboard.AllowPaging = false;
                    dgDashboard.Columns[0].Visible = false;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename = ExcelExport.xls");
                    Response.Charset = "";
                    Response.Buffer = true;
                    this.EnableViewState = false;
                    StringWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);
                    fillDashboard();
                    dgDashboard.RenderControl(hw);
                    HttpContext.Current.Response.Write(tw.ToString());
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.End();
                }
                catch (Exception Ex)
                {
                    ErrorLog obj = new ErrorLog(Session["PROGRAMCODE"].ToString(), Ex.Message, Ex.StackTrace, this.Page.ToString(), new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, System.Net.Dns.GetHostEntry(Context.Request.ServerVariables["REMOTE_HOST"]).HostName.ToString(), Session["EMPNUMBER"].ToString(), HttpContext.Current.User.Identity.Name.ToString());
                }
                HttpContext.Current.Response.End();
            }
        
            protected void imgExcelExport_Click(object sender, ImageClickEventArgs e)
            {
                fnExcelUpload();
            }
            #endregion  
    
    #region "   Summary - Excel Upload                      "
            private void fnExcelUpload()
            {
                try
                {
                    dgDashboard.AllowPaging = false;
                    dgDashboard.Columns[0].Visible = false;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename = ExcelExport.xls");
                    Response.Charset = "";
                    Response.Buffer = true;
                    this.EnableViewState = false;
                    StringWriter tw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(tw);
                    fillDashboard();
                    dgDashboard.RenderControl(hw);
                    HttpContext.Current.Response.Write(tw.ToString());
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.End();
                }
                catch (Exception Ex)
                {
                    ErrorLog obj = new ErrorLog(Session["PROGRAMCODE"].ToString(), Ex.Message, Ex.StackTrace, this.Page.ToString(), new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, System.Net.Dns.GetHostEntry(Context.Request.ServerVariables["REMOTE_HOST"]).HostName.ToString(), Session["EMPNUMBER"].ToString(), HttpContext.Current.User.Identity.Name.ToString());
                }
                HttpContext.Current.Response.End();
            }
        
            protected void imgExcelExport_Click(object sender, ImageClickEventArgs e)
            {
                fnExcelUpload();
            }
            #endregion
