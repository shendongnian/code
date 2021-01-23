    // Easy to use
    context.BulkSaveChanges();
    
    // Easy to customize
    context.BulkSaveChanges(bulk => bulk.BatchSize = 100);
    
    // Perform Bulk Operations
    context.BulkDelete(customers);
    context.BulkInsert(customers);
    context.BulkUpdate(customers);
    
    // Customize Primary Key
    context.BulkMerge(customers, operation => {
       operation.ColumnPrimaryKeyExpression = 
            customer => customer.Code;
    });
