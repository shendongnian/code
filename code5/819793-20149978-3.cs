    var tblAddresses = new DataTable();
    tblAddresses.Columns.Add("Place");
    tblAddresses.Columns.Add("Street");
    tblAddresses.Columns.Add("City");
    tblAddresses.Columns.Add("Post Code");
    tblAddresses.Columns.Add("Country");
    string[] input = new[]{"90 Howard Square,Old street, London, EC2 4RA, Uk"};
    foreach(string address in input)
        tblAddresses.Rows.Add(address.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries));
