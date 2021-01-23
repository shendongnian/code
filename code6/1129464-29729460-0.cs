    use code for export gridview data. 
    protected void btnexportreport_Click(object sender, EventArgs e)
            {
                ExportGridToExcel();
            }
    
            private void ExportGridToExcel()
            {
               
                Response.AddHeader("content-disposition", "attachment;filename=Excelsheet" + DateTime.Now.Ticks.ToString() + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
    
                gvdisplay.RenderControl(HtmlTextWriter);
    
    
                Response.Write(StringWriter.ToString());
                Response.End();
                Response.Clear();
    
    
            }
