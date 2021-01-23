    // url doesn't matter unless you will use data service to execute the call
    var dsContext = new DataServiceContext(new Uri("http://stackoverflow"));
    // need to pass in the controller into CreateQuery - could create an extension method to pluralize the type to not have to pass it in. 
    var query = dsContext.CreateQuery<Product>("/api/products").Where(p => p.Category == "Cars");
    // ToString will output the url
    var uri = new Uri(query.ToString());
    // Grab just the path and query
    var path = new Uri(uri.PathAndQuery, UriKind.RelativeOrAbsolute);
    await client.GetAsync(path); // this will call the api not DataServiceContext
