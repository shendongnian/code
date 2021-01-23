    public override void Configure(Container container)
    {
          var store = new DocumentStore(){
              Url = "http://",
              DefaultDatabase = "xxxxxx"
          }.Initialize();
    
          // register ravendb
          container.Register(store);
          container.Register(c =>c.Resolve<IDocumentStore>).OpenSession()).ReusedWithin(ReuseScope.Request);
     }       
