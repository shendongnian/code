    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
	  if (e.Row.RowType.Equals(DataControlRowType.Pager)) {
		TableRow pTableRow = (TableRow)e.Row.Cells[0].Controls[0].Controls[0];
		foreach (TableCell cell in pTableRow.Cells) {
			foreach (Control control in cell.Controls) {
				if (control is LinkButton) {
					LinkButton lb = (LinkButton)control;
					lb.Attributes.Add("onclick", "ScrollToTop();");
				}
			}
		}
	  }
    }
