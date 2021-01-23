    MyContext proxy = new MyContext(new Uri("http://localhost:62717/MyService.svc/", UriKind.Absolute));
    var MyEntity = proxy.MyEntity.Where(x=>x.id = 1).First();
    // ...
    // Later in the code:
    // A new proxy is created. This will cause the failure in the next line.
    proxy = new MyContext(new Uri("http://localhost:62717/MyService.svc/", UriKind.Absolute));
    proxy.LoadProperty(MyEntity, "RelatedEntity");
    // Make sure you reuse the same proxy as the one you loaded your MyEntity object.
