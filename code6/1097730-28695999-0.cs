    protected void ExportToExcel(object sender, EventArgs e)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=exportdata.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                    GridView gv = new GridView();
                    gv.DataSource = "your filtered query result"; // query the database and get the filtered data and bind the grid
                    gv.DataBind();
    
                    gv.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
    
            public override void VerifyRenderingInServerForm(Control control)
            {
               
            }
