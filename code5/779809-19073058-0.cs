    // Add item to the collection
    if (typeof(IList).IsAssignableFrom(collectionType)) {
       var addMethod = collectionType.GetMethod("Add", new[] { itemObject.GetType() });
       if (addMethod == null)
          throw new SerializationException("Failed to find expected IList.Add method.");
       addMethod.Invoke(collectionObject, new[] { itemObject });
    } else if (typeof(IDictionary).IsAssignableFrom(collectionType)) {
       var addMethod = collectionType.GetMethod("Add", new[] { typeof(Type), itemObject.GetType()}
       if (addMethod == null)
          throw new SerializationException("Failed to find expected IDictionary.Add method.");
       addMethod.Invoke(collectionObject, new[] { itemType, itemObject });
    }
