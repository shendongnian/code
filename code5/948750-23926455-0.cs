    public void CerateExcel()
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=Name.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
    
            form1.RenderControl(hw); //form1 it's name of you .aspx page (a form name with runat='server' tag)
    
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
