    // convert rows to nodes
    var nodes = dt.Rows.Cast<DataRow>().Select(r => new Node
    {
        Id = r["id"].ToString(),
        ParentId = r["parentId"].ToString(),
        IsEmergency = (r["isEmergency"] as bool? == true)
    }).ToList();
    
    // group and index by parent id
    var grouped = nodes.GroupBy(n => n.ParentId).ToDictionary(g => g.Key);
    
    // match up child nodes
    foreach (var n in nodes)
    {
        n.Children = grouped.ContainsKey(n.Id) ? (IEnumerable<Node>)grouped[n.Id] : new Node[0];
    }
    
    // select top nodes
    var top = grouped.ContainsKey("0") ? (IEnumerable<Node>)grouped["0"] : new Node[0];
