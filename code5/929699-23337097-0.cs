    public override bool Equals(object obj) 
    {
        Catalog cat =  obj as Catalog;
        if (cat == null)
        {
            return false;
        }
        return (this.Name.Equals(cat.Name));           
    }
