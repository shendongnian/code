    var itemArray = new object[] { 
        "65E6BD38-2806-S15G-9DC5-9DE908333996", 3, 0, "News", "News", 
        Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
        "Publish", "mes", 0, 0, 0, "null", "null", "Active" };
    for (int i = 0; i < 10000; i++)
    {
        var r = dtMessageDetails.NewRow();
        r.ItemArray = itemArray;
        dtMessageDetails.Rows.Add(r);
    }
