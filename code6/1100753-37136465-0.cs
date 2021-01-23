    protected void ExportBtn_Click(object sender, EventArgs e)
    {     
      ResultGrid();// Datagrid function to fill value 
     Response.ClearContent();
     Response.Buffer = true;
     Response.AddHeader("content-disposition", string.Format("attachment;    filename={0}", "myexcelfile.xls"));
     Response.ContentType = "application/ms-excel";
     StringWriter sw = new StringWriter();
     HtmlTextWriter ht = new HtmlTextWriter(sw);
     ResultGrid.RenderControl(ht);
     Response.Write(sw.ToString());
     Response.End();
    }
   
