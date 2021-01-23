    radGridView1.CellEndEdit += (s, e) =>
    {
        if (e.Column == radGridView1.Columns["Quantity"])
        {
            var row = radGridView1.CurrentRow.Cells;
            row["Total Price"].Value =
                (int)row["Quantity"].Value * (decimal)row["Item Price"].Value;
        }
    };
