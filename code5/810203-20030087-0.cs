    public static T CreateNew<T>(out string errmsg) where T : class
        {
            errmsg = string.Empty;
            // Loading the DAL assembly as you cannot allways be sure that it is loaded,
            // as it can be used from the GAC and thereby not accessible as a loaded assembly.
            AppDomain.CurrentDomain.Load("DAL");
            // From loaded assemblies get the DAL and get the specific class that implements 
            // the interface provided, <T>.
            // It is assumed for the time being, that only one BLL dataobject implements the interface.
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(T).IsAssignableFrom(p) && p.IsClass)
                .FirstOrDefault();
            try
            {
                // Create an instance of the class that implements the interface in question, unwrap it 
                // and send it back as the interface type.
                var s = Activator.CreateInstance("DAL", type.FullName);
                return (T)s.Unwrap();
            }
            catch (Exception ex)
            {
                errmsg = ex.ToString();
                return null;
            }
            
        }
