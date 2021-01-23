    DataSet ds = new DataSet("Stock");
    ds.Tables.Add(new DataTable("Assortment"));
    ds.Tables[0].Columns.Add("Item", typeof(string));
    ds.Tables[0].Columns.Add("Quantity", typeof(Int16));
    ds.Tables[0].Rows.Add("Sock", 1);
    ds.Tables[0].Rows.Add("Puppet", 2);
    ds.WriteXmlWithCurrentDate(@"c:\temp\xml.xml");
