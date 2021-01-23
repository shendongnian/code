     // my table storage class
     TableStorage ts = new TableStorage("ContactData");
    
     // search with expression
     List<DynamicTableEntity> results = ts.GetSome<DynamicTableEntity>(t => t.Properties["FirstName"].StringValue == "Darren");
