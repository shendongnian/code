    if (updatedItem != null)
    {
        GridViewRow row = resultsGridView.Rows[e.RowIndex];
        var res = row.FindControl("ctl00$ContentPlaceHolder1$resultsGridView$ctl02$ctl03");
        updatedItem.DepartureCity = ((TextBox)(row.Cells[2].Controls[0])).Text;
        updatedItem.ArrivalCity = ((TextBox)(row.Cells[3].Controls[0])).Text;
        updatedItem.DepartureTime = DateTime.Parse(((TextBox)(row.Cells[4].Controls[0])).Text);
        updatedItem.ArrivalTime = DateTime.Parse(((TextBox)(row.Cells[5].Controls[0])).Text);
        modelContainer.SaveChanges();
    }
