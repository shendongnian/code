    protected void gvContents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Text = e.Row.Cells[3].Text.Replace("Special", "<span class='redWord'>Special</span>")
                                  .Replace("Perishable", "<span class='blueWord'>Perishable</span>")
                                  .Replace("Danger", "<span class='yellowWord'>Danger</span>");
        }
    }
