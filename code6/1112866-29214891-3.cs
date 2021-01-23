	protected void gvReport_OnRowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Select")
		{
            //Find row data
			foreach (DataRow row in SessionDataTbl.Rows)
			{
				if (row["Month"].Equals(e.CommandArgument))
				{
					txtPerson.Text = row["Person"].ToString();
                    //other text boxes, etc.
					break;
				}
			}
            //Add row color change
			Button btn = e.CommandSource as Button;
			if (btn != null)
			{
				System.Web.UI.Control field = btn.Parent;
				if (field != null)
				{
					GridViewRow row = field.Parent as GridViewRow;
					if (row != null)
					{
						const string backColor = "background-color";
                        //Remove any previous backcolor
						foreach (GridViewRow rw in gvReports.Rows)
						{
							rw.Style.Remove(backColor);
						}
						row.Style.Add(backColor, "yellow");
					}
				}
			}
        }
	}
