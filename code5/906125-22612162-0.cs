    var collection = db.GetCollection<Node>("nodes");
    var nodes = collection.Find(Query.And( // might want Query.Or instead?
                    Query<Node>.Exists(p => p.Tests),
                    Query<Node>.Exists(p => p.Studies)).SetSnapshot();
    
    foreach(var node in nodes) {
      // maybe you want to move the Tests and Studies to MainEntries here?
      node.MainEntries = new List<MainEntries>();
      node.Test = null;
      node.Studies = null;
      collection.Update(node);
    }
