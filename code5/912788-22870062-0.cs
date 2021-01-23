    void Delete(bool recursive = false)
    {
        if(recursive)
            RecursiveDelete();
        if(this.Parent != null)
            this.Parent.Children.Remove(this);
        using(var db = new MyContext())
        {
            db.SaveChanges();
        }
    }
    void RecursiveDelete()
    {
        foreach(var child in Children.ToArray())
        {
            child.RecursiveDelete();
            Children.Remove(child);
        }
        using(var db = new MyContext())
        {
            db.Nodes.Attach(this);
            db.Entry(this).State = EntityState.Deleted();
        }
    }
