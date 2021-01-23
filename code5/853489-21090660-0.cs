    public override bool Equals(object obj)
    {
        return Equals(obj as $className$);
    }
    
    internal bool Equals($className$ other)
    {
        // If parameter is null, return false. 
        if (ReferenceEquals(other, null))
            return false;
    
        // Optimization for a common success case. 
        if (// TODO: Compare this object members with other.)
            return true;
    
        return ($compareObjects$);
    }
