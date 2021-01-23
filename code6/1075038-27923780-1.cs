    public Transaction(DataRow row)
    {
        LastName = row.Field<string>("LastName");
        FirstName = row.Field<string>("FirstName");
        MI = row.ItemArray[3].ToString()[0];
        ContactNumber = row.ItemArray[4].ToString();
        Hours = int.Parse(row.ItemArray[5].ToString());
        CheckIn = (DateTime)row.ItemArray[6];
        roomNumber = int.Parse(row.ItemArray[9].ToString());
        Paid = row.Field<int?>("Paid") ?? 0;
        TotalBill = row.Field<int?>("TotalBill") ?? 0;
    }
