     DataSet dataSet = new DataSet();
     DataTable dataTable = dataSet.Tables.Add("Items");
     dataTable.Columns.Add("Site", typeof(string));
     dataTable.Columns.Add("ItemID", typeof(UInt64));
     dataTable.Columns.Add("ItemName", typeof(string));
     dataTable.Columns.Add("ListedPrice", typeof(decimal));
     dataTable.Columns.Add("Currency", typeof(string));
     dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ItemID"]
     dataTable.Rows.Add("mysite",44322,"werwer", 345345,"USD");
     
     dataGridView1.DataSource = dataSet.Tables["Items"]
