    using (var command = new OleDbCommand
    {
        Connection = connection,
        CommandText =
            "insert into [BillItem] (billNumber, storeItemNumber, numberOfItems, priceForEach, totalValue) values (?, ?, ?, ?, ?)"
    })
    {
        for (int i = 0; i < DataGridViewAddSale.Rows.Count; i++)
        {
            command.Parameters.Clear();
            var rowCells = DataGridViewAddSale.Rows[i].Cells;
            command.Parameters.AddWithValue("@p1", txtBillNo.Text);
            command.Parameters.AddWithValue("@p2", rowCells["ColCordNo"].Value);
            command.Parameters.AddWithValue("@p3", rowCells["ColQty"].Value);
            command.Parameters.AddWithValue("@p4", rowCells["ColUnitPrice"].Value);
            command.Parameters.AddWithValue("@p5", rowCells["ColTotalValue"].Value);
            command.ExecuteNonQuery();
        }
    }
