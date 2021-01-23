    public bool IsValidDelta<T>(Delta<T> delta) where T: class
    {
       // list of property names that can't be patched
       var nonEditablePropertyNames = from p in typeof(T).GetProperties()
                        let attr = p.GetCustomAttribute(typeof(NonEditableAttribute))
                        where attr != null
                        select p.Name;
       // list of property names that were changed
       var changedPropertyNames = delta.GetChangedPropertyNames();
       
       // check if changedPropertyNames contains any of propertyNames, 
       // if yes return false, if no return true;
    }
