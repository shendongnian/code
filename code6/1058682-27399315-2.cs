    Response.ClearContent();
    Response.ClearHeaders();
    
    Response.AddHeader("content-disposition", "attachment;filename=Demo.xls");
    Response.ContentType = "application/ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    
    System.IO.StringWriter sw = new System.IO.StringWriter();
    System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
    
    Label lblheader = new Label();
    lblheader.Font.Size = new FontUnit(14, UnitType.Point);
    lblheader.Font.Bold = true;
    lblheader.Text = "Demo Details";
    lblheader.RenderControl(hw);
    
    
    
    GrdExcel.Visible = true;
    GrdExcel.RenderControl(hw);
    
    Response.Write(sw.ToString());
    Response.Flush();
    Response.End();
    GrdExcel.Visible = false;
