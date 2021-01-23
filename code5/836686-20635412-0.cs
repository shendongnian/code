    public class EndPointLoader : MarshalByRefObject
    {
        public void Load(string path, string endPointName)
        {
            Assembly.LoadFrom(path);
    
            var classTypes = AppDomain.CurrentDomain.GetAssemblies()
                                      .SelectMany(s => s.GetTypes())
                                      .Where(p => p.FullName == endPointName)
                                      .ToList();
    
            for (int i = 0; i < classTypes.Count; i++)
            {
                 ....
            }
        }
    } 
