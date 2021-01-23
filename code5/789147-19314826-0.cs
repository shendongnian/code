    var view = new System.Data.DataView(table);
    view.Sort = "id";
    foreach(var id in new [] {1,2,3})
    {
        view.RowFilter = "id = " + id.ToString();
        var result = view.ToTable();
    }
    
