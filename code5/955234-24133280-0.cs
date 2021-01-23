        public PartsManager()
        {
             ConstructContainer();
        }
        private void ConstructContainer()
        {
            var catalog = new DirectoryCatalog(@"C:\plugins\");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            container.SatisfyImportsOnce(this);
        }
