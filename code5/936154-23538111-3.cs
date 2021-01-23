    var table = new System.Data.DataTable();
    table.Columns.Add("PartnerName", typeof(string));
    table.Columns.Add("CreditCol", typeof(int));
    table.Columns.Add("DebitCol", typeof(string));
    table.Columns.Add("AmountCol", typeof(int));
    table.Rows.Add("P1", 10, "20", 30);
    table.Rows.Add("P2", 1, "2", 3);
    table.Rows.Add("P3", 3, "1", 10);
    table.Rows.Add("P2", 1, "100", 200);
