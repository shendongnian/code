    The given below code is working perfectly.
---------------------------------------------------
    foreach (GridViewRow row in GridView2.Rows)
        {
          if (row.RowType == DataControlRowType.DataRow)
            {
               CheckBox chkRow = (row.Cells[2].FindControl("CheckBox1") as CheckBox);
                 if (chkRow.Checked)
                    {
                       string ItemName = row.Cells[0].Text;
                       string Quantity = row.Cells[1].Text;
    
                       rs.testInsert(ItemName, Quantity);
                    }
            }
        }
