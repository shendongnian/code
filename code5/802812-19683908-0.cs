    protected void gvOfcManHole_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
			GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
			
			TableHeaderCell headerTableCell = new TableHeaderCell();
			headerTableCell.RowSpan = 2;
			headerTableCell.Text = "SL No";
						
			headerRow1.Controls.Add(headerTableCell);
			headerTableCell = new TableHeaderCell();
			headerTableCell.ColumnSpan = 3;
			headerTableCell.Text = "MH1  <br> M. Mark";
			headerRow1.Controls.Add(headerTableCell);
			//for (int i = 1; i <= Convert.ToInt16(txtHHColumn.Text); i++)
			for (int i = 1; i <= 1; i++)
			{
				headerTableCell = new TableHeaderCell();
				headerTableCell.ColumnSpan = 3;
				headerTableCell.Text = "HH" + i + "<br> M. Mark";
				headerRow1.Controls.Add(headerTableCell);
			}
			headerTableCell = new TableHeaderCell();
			headerTableCell.ColumnSpan = 3;
			headerTableCell.Text = "MH2 <br> M. Mark";
			headerRow1.Controls.Add(headerTableCell);
			TableHeaderCell headerCell1;
			TableHeaderCell headerCell2;
			TableHeaderCell headerCell3;
			//for (int i = 1; i < Convert.ToInt16(3 + Convert.ToInt16(txtHHColumn.Text)); i++)
			for (int i = 1; i < Convert.ToInt16(3 + 1); i++)
			{
				headerCell1 = new TableHeaderCell();
				headerCell2 = new TableHeaderCell();
				headerCell3 = new TableHeaderCell();
				headerCell1.Text = "D Entry";				
				headerCell2.Text = "D Exit";
				headerCell3.Text = "Slack";
												
				headerRow2.Controls.Add(headerCell1);
				headerRow2.Controls.Add(headerCell2);
				headerRow2.Controls.Add(headerCell3);
			}		
						
			gvOfcManHole.Controls[0].Controls.AddAt(0, headerRow2);
			gvOfcManHole.Controls[0].Controls.AddAt(0, headerRow1);
		}  
	}
