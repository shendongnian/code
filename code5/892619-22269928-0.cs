    public virtual ObjectResult<MyClass> MyStoredProcedure(System.Data.Spatial.DbGeography location, MergeOption mergeOption)
    {
        var locationParameter = location != null ?
            new ObjectParameter("location", location) :
            new ObjectParameter("location", typeof(System.Data.Spatial.DbGeography));
    }
