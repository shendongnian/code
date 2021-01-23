    DataTable tblMaster = new DataTable();
    DataColumn dc = new DataColumn("pday", Type.GetType("System.String"));
    tblMaster.Columns.Add(dc);
    tblMaster.Rows.Add(new Object[]{"Nov 28 2011 12:00AM"});
    tblMaster.Rows.Add(new Object[]{"Apr 27 2013 11:10PM"});
    tblMaster.Rows.Add(new Object[]{"Jul 18 2011 12:00AM"});
    tblMaster.Rows.Add(new Object[]{"Mar 19 2012 10:01PM"});
    
    DateTime PDay = new DateTime(2011,11,28);
    
    //foreach(var row in tblMaster.AsEnumerable())
    //{
    //	Console.WriteLine("{0}", Convert.ToDateTime(row[0]));
    //}
    
    var qry = tblMaster.AsEnumerable()
             .Where(p=>Convert.ToDateTime(p.Field<string>("pday"))==PDay);
    //qry.Dump();
