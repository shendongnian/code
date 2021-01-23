    private static void SetEntityPropertiesRequired<TEntity>(DbModelBuilder modelBuilder, Entity entity)
    {
        //set all decimal properties in Projection Entity to be Required
        var decimalproperties = typeof (TEntity).GetProperties()
        ...
