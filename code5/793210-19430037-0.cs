    void gvPortfolio_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Footer)
        {
            // Once you know you are in the footer row
            // the sender object is the GridView and you can get the datasource
            // loop thru the datatable adding up the values you want
            // For example: let say column 3 have the number
            // **** code is not tested - writing from memory ***
            int total = 0;
            int column = 3;
            foreach(DataRow row in (DataTable)(sender.DataSource).Rows)
            {
                  if (!row.IsNull(column))
                  {
                      // probably need more checking to make sure we have a valid integer
                      total += Convert.ToInt32(row[column]);
                  }
            }
            e.Row.Cells[column].Text = total.ToString();
        }
    }
