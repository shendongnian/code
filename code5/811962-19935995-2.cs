    DataSet das = new DataSet();
    das.DataSetName = "Stock";
    das.Tables.Add(new DataTable("Assortment"));
    das.Tables[0].Columns.Add("Item", typeof(string));
    das.Tables[0].Columns.Add("Quantity", typeof(Int16));
    das.Tables[0].Rows.Add("Sock", 1);
    das.Tables[0].Rows.Add("Puppet", 2);
    das.WriteXmlWithCurrentDate("c:\temp\xml.xml")
    
