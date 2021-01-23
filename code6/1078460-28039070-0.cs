    protected void btnExport_Click(object sender, EventArgs e)
    {
    Response.ClearContent();
    Response.Buffer = true;
    Response.AddHeader("content-disposition",string.Format("attachment;filename={0}", "Customers.xls"));
    Response.ContentType = "application/ms-excel";
    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    gvDetails.AllowPaging = false;
    BindGridview();
    //Change the Header Row back to white color
    gvDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
    //Applying stlye to gridview header cells
    for (int i = 0; i < gvDetails.HeaderRow.Cells.Count; i++)
    {
     gvDetails.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
    }
    gvDetails.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.End();
    }
 
    public override void VerifyRenderingInServerForm(Control control)
    {
    /* Verifies that the control is rendered */
    }
