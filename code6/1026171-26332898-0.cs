    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridView FooterGrid = (GridView)sender;
            GridViewRow FooterRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
            TableCell Cell_Footer = new TableCell();
            Cell_Footer.Text =""; // As per your requirement
            Cell_Footer.HorizontalAlign = HorizontalAlign.Center;
            Cell_Footer.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Footer);
     
            Cell_Footer = new TableCell();
            Cell_Footer.Text = ""; // As per your requirement
            Cell_Footer.HorizontalAlign = HorizontalAlign.Center;
            Cell_Footer.ColumnSpan = 1;
            Cell_Footer.RowSpan = 2;
            FooterRow.Cells.Add(Cell_Footer);
     
            Cell_Footer = new TableCell();
            Cell_Footer.Text = ""; // as per your requiremnt
            Cell_Footer.HorizontalAlign = HorizontalAlign.Center;
            Cell_Footer.ColumnSpan = 3;
            FooterRow.Cells.Add(Cell_Footer);
     
            GridView1.Controls[0].Controls.AddAt(0, FooterRow);
     
        }
    }
