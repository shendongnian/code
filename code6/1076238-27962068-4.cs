    var parents = new MyDataHandler.GetAllParents()
        .ToDataTableModel(p => p.Id, p => null, p => p.Name);
    var childs = new MyDataHandler.GetAllChilds()
        .ToDataTableModel(c => c.Id, c => c.ParentId, c => c.Name);
    var table = parents.Concat(childs).ToList().ToDataTable();
