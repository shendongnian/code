    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        //Change the number here to refer to the column you are checking
        if(string.IsNullOrEmpty(e.Row.Cells[1].Text))
        {
            e.Row.BackColor = Color.Gray;
        }
    }
