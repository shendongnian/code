			protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					var yo = (YOUR-OBJECT)e.Row.DataItem;
					if(yo.Status !== null OR yo.Status != 'Not Reviewed'){
					//Find the DropDownList in the Row
					DropDownList abc = (e.Row.FindControl("DropDownList9") 
					as  DropDownList);
					abc.Enabled = false;
					}
				}
			}
