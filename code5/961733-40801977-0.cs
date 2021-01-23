    using ObjectFlattenerRecomposer;
    
    //Flatten object and convert it to EntityProperty Dictionary
    
    Dictionary<string, EntityProperty> flattenedProperties = EntityPropertyConverter.Flatten(complexObject);
    
    // Create a DynamicTableEntity and set its PK and RK
    
    DynamicTableEntity dynamicTableEntity = new DynamicTableEntity(partitionKey, rowKey);
    
    dynamicTableEntity.Properties = flattenedProperties;
    
    // Write the DynamicTableEntity to Azure Table Storage using client SDK
    
    //Read the entity back from AzureTableStorage as DynamicTableEntity using the same PK and RK
    
    DynamicTableEntity entity = [Read from Azure using the PK and RK];
    
    //Convert the DynamicTableEntity back to original complex object.
    
    Imagine original complexObject was of type Order.
    
    Order order = EntityPropertyConverter.ConvertBack<Order>(entity.Properties);
