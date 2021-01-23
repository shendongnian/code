    // Define other methods and classes here
    // 6. IDynamicMetaObjectProvider
    // This supports the DLR's dynamic objects
    if (accessor == null && 
    	SystemCoreHelper.IsIDynamicMetaObjectProvider(item))
    {
    	accessor = SystemCoreHelper.NewDynamicPropertyAccessor(
    					item.GetType(), propertyName);
    }
