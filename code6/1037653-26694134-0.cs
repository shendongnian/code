    var records = from t1 in x12.InterchangeDataSet.Tables["PO1"].AsEnumerable()
                  join t2 in x12.InterchangeDataSet.Tables["DTM"].AsEnumerable() 
                  on t1.Field<int?>("Loop_Id") equals t2.Field<int?>("Loop_Id")
                  select new {
                    PO101 = t1.Field<string>("PO101"),
                    PO109 = t1.Field<string>("PO109"),
                    PO102 = t1.Field<string>("PO102"),
                    PO103 = t1.Field<string>("PO103"),
                    PO104 = t1.Field<string>("PO104"),
                    DTM02 = t2.Field<string>("DTM02")
                 };
    foreach(var x in records)
    {
        DataRow newRow = tblr.Rows.Add();
        newRow.SetField(0, x.PO101);
        newRow.SetField(1, x.PO109);
        newRow.SetField(2, x.PO102);
        newRow.SetField(3, x.PO103);
        newRow.SetField(4, x.PO104);
        newRow.SetField(5, x.DTM02);       
    }
