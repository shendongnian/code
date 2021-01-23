    public static class Util 
    {
        private static Dictionary<string, Type> guidMap;
        static Util()
        {
            guidMap = new Dictionary<string, Type>();
            AppDomain.CurrentDomain.AssemblyLoad += (s, e) =>
            {
                try 
                {
                    _ScanAssembly(e.LoadedAssembly);
                } 
                catch 
                {
                }
            };
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                try 
                {
                    _ScanAssembly(a);
                } 
                catch 
                {
                }
            }
        }
        private static void _ScanAssembly(Assembly a)
        {
            foreach (Type t in a.GetTypes())
            {
                var attrs = t.GetCustomAttributes<GuidAttribute>(false);
                foreach (var item in attrs) {
                    if (!guidMap.ContainsKey(item.Value.ToLower()))
                        guidMap.Add(item.Value.ToLower(), t);
                }
            }
        }
        public static Dictionary<string, Type> GuidMap 
        {
            get 
            {
                return guidMap;
            }
        }
    }
