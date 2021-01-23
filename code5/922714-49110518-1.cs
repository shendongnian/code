    public static class AssemblyHelper
    {
            public static List<Type> GetSubclassesOf(Type type, bool ignoreSystem)
            {
                List<Type> lReturn = new List<Type>();
                foreach (var a in System.Threading.Thread.GetDomain().GetAssemblies())
                {
                    if (ignoreSystem && a.FullName.StartsWith("System."))
                    {
                        continue;
                    }
                    foreach (var t in a.GetTypes())
                    {
                        if (t.IsSubclassOf(type) || (type.IsInterface && t.GetInterfaces().FirstOrDefault(e => e.FullName == type.FullName) != null))
                        {
                            lReturn.Add(t);
                        }
                    }
                }
                return lReturn;
            }
    }
