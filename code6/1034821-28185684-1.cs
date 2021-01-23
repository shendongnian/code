	protected void btnXlsExport_Click(object sender, EventArgs e)
	{
		Response.Clear();
		Response.Buffer = true;
		Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
		Response.Charset = "";
		Response.ContentType = "application/vnd.ms-excel";
		StringWriter sw = new StringWriter();
		HtmlTextWriter hw = new HtmlTextWriter(sw);
		gvStandard.AllowPaging = false;
		gvStandard.DataBind();
		for (int i = 0; i <= gvStandard.Rows.Count - 1; i++) {
			GridViewRow row = gvStandard.Rows(i);
			foreach (TableCell cell in row.Cells) {
				if (cell.HasControls() == true) {
					if (cell.Controls(0).GetType().ToString() == "System.Web.UI.WebControls.CheckBox") {
						CheckBox chk = (CheckBox)cell.Controls(0);
						if (chk.Checked) {
							cell.Text = "True";
						} else {
							cell.Text = "False";
						}
					}
				}
			}
		}
		gvStandard.HeaderRow.Style.Add("background-color", "#FFFFFF");
		gvStandard.RenderControl(hw);
		Response.Output.Write(sw);
		Response.Flush();
		Response.End();
	}
