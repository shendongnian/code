    var builder = new ODataConventionModelBuilder();
    builder.Namespace = "X";
    builder.ContainerName = "Y";
    builder.EntitySet<Z>("Z");
    var types = AppDomain.CurrentDomain.GetAssemblies()
    	.SelectMany(a => a.GetTypes())
    	.Where(t => t.IsSubclassOf(typeof(Z)));
    
    foreach (var type in types)
    	builder.Ignore(types.ToArray());
     
    //additional mapping of derived types if needed here
    var edmModel = builder.GetEdmModel();
