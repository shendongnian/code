    public virtual ObjectResult<MyClass> MyStoredProcedure(System.Data.Spatial.DbGeography location, MergeOption mergeOption)
    {
        var locationParameter = location != null ?
            new ObjectParameter("location", location) :
            new ObjectParameter("location", typeof(System.Data.Spatial.DbGeography));
        // EDIT: Neglected to copy this part in during original post
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MyClass>("MyStoredProcedure", mergeOption, locationParameter);
    }
