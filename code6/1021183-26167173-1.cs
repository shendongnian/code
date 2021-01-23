    var parent = new Parent()
    parent.Childs = new List<Child>()
    var child1 = new Child();
    var child2 = new Child();
    parent.Childs.Add(child1);
    parent.Childs.Add(child2);
    dbContex.Parents.Add(parent);
    dbContex.SaveChanges();
    
    
