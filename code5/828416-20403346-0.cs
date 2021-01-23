     public void ListClasses()
            {
                var assembly = Assembly.GetExecutingAssembly();
                var allTypes = assembly.GetTypes();
                Debug.WriteLine("Namespace \t Class \t Property \t Type");
                foreach(var type in allTypes)
                {
                    var props = type.GetProperties();
                    foreach(var prop in props)
                    {
                        Debug.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", type.Namespace, type.Name, prop.Name, prop.PropertyType));
                    }
                }
            }
