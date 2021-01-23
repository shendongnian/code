    public List<MenuItem> FlattenedChildNodes {
      get {
        var ret = new List<MenuItem>();
    
        foreach (var item in ChildMenuItems) {
           ret.Add(item);
           
           if(item.ChildMenuItems != null) {
              ret.AddRange(item.FlattenedChildNodes);
           }
        }
    
        return ret;
      }
    }  
  
    public bool IsLastChild {
          get {
            if (ParentMenuItem == null) // return false if we have no parent (it's the root node)
               return false;
            else // return true iff we're the last child in the parent's collection of children
               return (ParentMenuItem.FlattenedChildNodes.ToList().IndexOf(this) == (ParentMenuItem.FlattenedChildNodes.ToList().Count - 1));
          }
        }
