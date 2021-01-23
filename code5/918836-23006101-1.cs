    public bool Equals(TEntity other)
    {
        if (object.ReferenceEquals(null, other))
        {
            return false;
        }
        if (object.ReferenceEquals(this, other))
        {
            return true;
        }
        return this.id == other.Id;
    }
    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(null, obj))
        {
            return false;
        }
        if (object.ReferenceEquals(this, obj))
        {
            return true;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        return this.Equals(obj as TEntity);
    }
    public override int GetHashCode()
    {
        // ReSharper disable once NonReadonlyFieldInGetHashCode
        return this.id.GetHashCode();
    }
