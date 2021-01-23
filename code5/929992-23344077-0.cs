      public class CatalogItem
      {
        private readonly List<Module> mModuls;
        public IEnumerable<Module> Moduls
        {
          get { return mModuls; }
        }
        public string ShortName { get; set; }
        public CatalogItem()
        {
          mModuls = new List<Module>();
        }
        public void AddModule(Module module)
        {
          // Add a check that module is assigned.
          mModuls.Add(module);
        }
     }
