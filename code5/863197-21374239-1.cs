    void YourGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        // Display the company name in italics.
       //  I assume the index of Qty column is 4
        e.Row.Cells[4].Text = decimal.Parse(e.Row.Cells[4].Text)/decimal.Parse(txtOrderQuantity.Text) ;
      }
    }
