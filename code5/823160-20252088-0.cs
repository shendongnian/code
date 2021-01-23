    public static class Extensions
    {
        public static void AddModelToGrid<T>(
            this MVCxGridViewColumnCollection devExpCollection)
        {
            // you just need the T parameter, not a list
            typeof(T).GetProperties().ToList().ForEach((prop) =>
            {
                var displayName = 
                     (DisplayAttribute)prop.GetCustomAttribute(typeof(DisplayAttribute));
                string name = null;
                if (displayName != null)
                {
                    name = displayName.Name;
                }
                else
                {
                    name = prop.Name;
                }
                devExpCollection.Add(prop.Name, name);
            });
        }
    }
