    public class SelectListAuto<T>: SelectList
    {
        public SelectListAuto(IEnumerable list):base(list, GetId(typeof(T)), GetName(typeof(T)))
        {
        }
        
        static string GetId(Type t) {
           // you can have all kind logic to autowire up, ie use some convention
           return t.GetProperties()
                  .Where(p => p.Name.Equals("Id",StringComparison.OrdinalIgnoreCase))
                  .Select(p=>p.Name).First();
        }
        
        static string GetName(Type t) {
           // you can have all kind logic to autowire up, ie use some convention
           return t.GetProperties()
                  .Where(p => p.Name.IndexOf("Name", StringComparison.OrdinalIgnoreCase) > -1 )
                  .Select(p=>p.Name).First();
        }
    }
