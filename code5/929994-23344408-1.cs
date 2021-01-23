    public class Option
    {
        public string OptionID { get; set;}
    }
    public class Module
    {
        // if you need only one Option, why not create one public Option object, instead of an Array
        public Option Option = new Option();
        public string ModuleID { get; set; }
    }
    public class CatalogItem
    {
        public Module Module = new Module();
        public string ShortName { get; set; }
    }
    public class Katalog
    {
        private List<CatalogItem> items = new List<CatalogItem>();
        public Katalog()
        {
          for(int i = 0; i < 10; i++)
             items.Add(new CatalogItem());
        }
        public void SetCatalogItem()
        {
            foreach(CatalogItem ci in items)
            {
                ci.ShortName = "asdf";
                ci.Module.ModuleID = "5";
            }
        }
    }
