    An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key.
    System.InvalidOperationException: An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key.
       at System.Data.Objects.ObjectStateManager.AddEntry(IEntityWrapper wrappedObject, EntityKey passedKey, EntitySet entitySet, String argumentName, Boolean isAdded)
       at System.Data.Objects.ObjectContext.AddSingleObject(EntitySet entitySet, IEntityWrapper wrappedEntity, String argumentName)
       at System.Data.Objects.DataClasses.RelatedEnd.AddEntityToObjectStateManager(IEntityWrapper wrappedEntity, Boolean doAttach)
       at System.Data.Objects.DataClasses.RelatedEnd.AddGraphToObjectStateManager(IEntityWrapper wrappedEntity, Boolean relationshipAlreadyExists, Boolean addRelationshipAsUnchanged, Boolean doAttach)
       at System.Data.Objects.DataClasses.RelatedEnd.Add(IEntityWrapper wrappedTarget, Boolean applyConstraints, Boolean addRelationshipAsUnchanged, Boolean relationshipAlreadyExists, Boolean allowModifyingOtherEndOfRelationship, Boolean forceForeignKeyChanges)
       at System.Data.Objects.DataClasses.RelatedEnd.Add(IEntityWrapper wrappedEntity, Boolean applyConstraints)
       at System.Data.Objects.DataClasses.EntityReference`1.set_ReferenceValue(IEntityWrapper value)
       at System.Data.Objects.DataClasses.EntityReference`1.set_Value(TEntity value)
