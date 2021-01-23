    public override bool TrySetMember<T>(SetMemberBinder binder, Nullable<T> value)
    {
        properties[binder.Name] = value;
        propertyTypes[binder.Name] = typeof(Nullable<T>);
        return true;
    }
        
