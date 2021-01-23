    public class PluginContainer<T>
    {
        Type targetType = typeof(T);
        public virtual IList<Type> GetMatchingTypes()
        {
            Assembly[] currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            IList<Type> items = new List<Type>();
            if (currentAssemblies == null || currentAssemblies.Length == 0)
            {
                Console.WriteLine("No assemblies found!");
                return items;
            }
            foreach (Assembly ass in currentAssemblies)
            {
                try
                {
                    var types = ass.GetTypes();
                    foreach (var t in types)
                    {
                        if (t.IsInterface)
                        {
                            continue;
                        }
                        if (!(targetType.IsAssignableFrom(t)))
                        {
                            continue;
                        }
                        items.Add(t);
                    }
                }
                catch (ReflectionTypeLoadException rtle)
                {
                    /* In case the loading failed, scan the types that it was able to load */
                    Console.WriteLine(rtle.Message);
                    if (rtle.Types != null)
                    {
                        foreach (var t in rtle.Types)
                        {
                            if (t.IsInterface)
                            {
                                continue;
                            }
                            if (!(targetType.IsAssignableFrom(t)))
                            {
                                continue;
                            }
                            items.Add(t);
                        }
                    }
                }
                catch (Exception ex)
                {
                    /* General exception */
                    Console.WriteLine(ex.Message);
                }
            }
            return items;
        }
        public IList<T> GetPlugins()
        {
            IList<Type> matchingTypes = GetMatchingTypes();
            IList<T> items = new List<T>();
            if (matchingTypes == null || matchingTypes.Count == 0) 
            {
                Console.WriteLine("No matching types of {0} found", typeof(T).FullName);
                return null;
            }
            foreach (Type type in matchingTypes)
            {
                try
                {
                    T nObj = (T)Activator.CreateInstance(type);
                    items.Add(nObj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured trying to run {0}\r\n{1}", type.FullName, ex.Message);
                }
            }
            return items;
        }
    }
