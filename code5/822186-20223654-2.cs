    public static class App
    {
        public static string Name
        {
             get
             {
                 if (_name == null)
                 {
                     var assembly = typeof(App).Assembly;
                     var attribute = assembly
                         .GetCustomAttributes(typeof(AssemblyTitleAttribute), true)
                         .OfType<AssemblyTitleAttribute>()
                         .FirstOrDefault();
        
                    _name = attribute != null ? attribute.Title : "";
                 }
     
                 return _name;
             }
        }
        
        private string _name;
    }
