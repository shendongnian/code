    var detachedCriteria = DetachedCriteria.For<InventoryItemCategories>()
        // here we have to use the C# property names instead of the column names
        .Add(Restrictions.EqProperty("InventoryId"  // local table c, col inventory_id
                                   , "myAlias.ID")) // outer table i, col id
        .Add(Restrictions.Eq("CategoryId"           // local table c, col Category_Id   
                                   , myGuid))       // the parameter passed alá '805ce...
        .SetProjection(Projections.Property("Catgory_Id"));
