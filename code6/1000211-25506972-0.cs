    var store = new DocumentStore { Url = "http://localhost:8080" , DefaultDatabase = "MyDbName" };
                store.Initialize();
                var result= store.DatabaseCommands.Query("Raven/DocumentsByEntityName",
                    new IndexQuery { Query = "Tag : RunningTables" },null);
                result.Results.ForEach(x=>x.WriteTo(new JsonTextWriter(Console.Out)));
