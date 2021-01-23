    var parents = new List<MyData1>()
        .ToDataTableModel(p => p.Id, null, p => p.Name);
    var childs = new List<MyData2>()
        .ToDataTableModel(c => c.Id, c => c.ParentId, c => c.Name);
    var table = parents.Concat(childs).ToList().ToDataTable();
