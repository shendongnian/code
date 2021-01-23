    class Program : IPartImportsSatisfiedNotification
    {
        [Import(AllowDefault=true, AllowRecomposition=true)]
        private Lazy<NonShared>_nonShared; //Lazy<T> is needed for ReleaseExport to work.
        
        public void OnImportsSatisfied()
        {
            Console.WriteLine("Program.OnImportsSatisfied()");
        }
        
        static void Main()
        {
            new Program().Run();
        }
        
        private void Run()
        {
            var aggregateCatalog = new AggregateCatalog();
            using (var container = new CompositionContainer(aggregateCatalog ))
            {
                container.ComposeParts(this);
                //Check if the field is injected. It shouldn't be since the 
                //NonShared type is not known to the container yet..
                Console.WriteLine("NonShared field {0}", this._nonShared != null ? "exists" : "does not exist");
                //Add the NonShared type to a type catalog.
                var typeCatalog = new TypeCatalog(typeof(NonShared));
                //Add the TypeCatalog to the AggregateCatalog.
                aggregateCatalog.Catalogs.Add(typeCatalog);
                //Check if the field is injected. This time it should be.
                Console.WriteLine("NonShared field {0}", this._nonShared != null ? "exists" : "does not exist");
                    
                if(this._nonShared != null)
                {
                    //Access the lazy object so it gets a value.
                    this._nonShared.Value.ToString();
                    //Release the part. The Dispose method should be called.
                    container.ReleaseExport<NonShared>(this._nonShared);
                }
            }
        }
    }
