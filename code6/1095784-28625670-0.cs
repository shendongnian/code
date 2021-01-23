    foreach (GridViewRow row in grdRequest.Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@OrderID", SqlDbType.Int, 32, "OrderID").Value = lblOrderID.Text;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int, 32, "ItemID").Value = row.Cells[1].Text;
