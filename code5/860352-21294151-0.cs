             [ImportMany]
        private IEnumerable<Lazy<IPostHandler, IPostHandlerCapabilities>> _postHandlersPlugins = null;
        private CompositionContainer _compositionContainer;
             ......
            public void SomeInitFunction() 
            {
             catalog.Catalogs.Add(new AssemblyCatalog(assembly));
           
            _compositionContainer = new CompositionContainer(catalog);
           
            try
            {
                _compositionContainer.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                ;
            }
    }
