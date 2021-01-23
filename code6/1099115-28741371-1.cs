	protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlFieldCell dc in e.Row.Cells)
            {
                switch (dc.ContainingField.ToString())
                {
                    case ("Column1"):
                        dc.Width = 100;
                        dc.HorizontalAlign = HorizontalAlign.Right;
                        break;
                    case ("Column2"):
                    case ("Column3"):
                        dc.Width = 50;
                        break;
                    case ("Column4"):
                        dc.Width = 215;
                        break;
				}
			}
		}
	}
