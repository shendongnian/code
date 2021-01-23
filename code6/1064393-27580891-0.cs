    var session = ... // get curretn session
    CategoryPartRecord category = null;
    ContentMaterialCategoryRecord pair = null;
    MaterialPartRecord material  = null;
    
    var subquery = QueryOver.Of<ContentMaterialCategoryRecord>(() => pair)
        // now we will join Categories to be able to filter whatever property
        .JoinQueryOver(() => pair.CategoryPartRecord, () => category)
        // here is the filter
        // there could be IN, >= <= ...
        .Where(() => category.ID).In(1,2,3)
        ...
        // now we will return IDs of the Material we are interested in
        .Select(x => pair.MaterialPartRecord.Id);
    
    
    // finally the clean query over the Materials... 
    var listOfUsers = session.QueryOver<MaterialPartRecord>(() => material  )
        .WithSubquery
            .WhereProperty(() => material.Id)
            .In(subquery)
        // paging
        .Take(10)
        .Skip(10)
        .List<MaterialPartRecord>();
