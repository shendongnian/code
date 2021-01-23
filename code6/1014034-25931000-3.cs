    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        var typedObj = obj as Category;
        if (typedObj == null)
            return false;
        return Title == typedObj.Title && Id == typedObj.Id && Rank == typedObj.Rank;
    }
