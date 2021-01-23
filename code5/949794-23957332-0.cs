    public IObservable<Location> Get()
            {
                var locations = new Subject<Location>();
                Task.Run(() =>
                         {
                             var query = DocumentSession.Query<Foo, FooIndex>();
                             foreach (var document in DocumentSession.Advanced.Stream(query))
                             {
                                 locations.OnNext(document);
                             }
                             locations.OnCompleted();
                         });
                
                return locations;
            }
