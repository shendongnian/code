    //type you need to create generic version with
    var type = GetType().Assembly //assumes it is located in current assembly
                        .GetTypes()
                        .Single(t => t.Name == "MyType");
    
    //creating a closed generic method
    var method = GetType().GetMethod("Query")
                          .GetGenericMethodDefinition()
                          .MakeGenericMethod(type);
    //calling it on this object
    method.Invoke(this, null); //will print "Called Query with type: MyType"
