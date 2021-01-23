    public class CheckBasePage : Task
    {
        public override bool Execute()
        {
            var assm = Assembly.LoadFile("/path/to/WebsiteAssembly.dll");
            var types = assm.GetTypes();
            
            var pages = new List<string>();
            foreach (var t in types)
            {
                if (t.BaseType == typeof(Page) && t.Name != "BasePage")
                {
                    pages.Add(t.FullName);
                }
            }
            if (pages.Count > 0)
            {
                Log.LogError("The following pages need to inherit from BasePage: [" + string.Join(",", pages) + "]");
                return false;
            }
            return true;
        }
    }
