    [Serializable]
    public enum CompositeLoaderFilter
    {
        ImplementsInterface = 0,
        InheritsBaseClass = 1
    }
    [Serializable]
    public static class Composite
    {
        private static readonly CompositeManager manager = new CompositeManager();
        public static CompositeManager Manager { get { return manager; } }
    }
    [Serializable]
    public class CompositeManager : MarshalByRefObject
    {
        private SortedList<string, Type> m_addIns;
        public int GetInMemoryComponents(Type addInType, CompositeLoaderFilter filter)
        {
            m_addIns = internal_GetInMemoryServices(addInType, filter);
            return m_addIns.Count;
        }
        public int GetComponents(Type addInType, CompositeLoaderFilter filter)
        {
            string addInPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return GetComponents(addInPath, "*.dll", SearchOption.TopDirectoryOnly, addInType, filter);
        }
        public int GetComponents(string addInSearchPattern, Type addInType, CompositeLoaderFilter filter)
        {
            string addInPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return GetComponents(addInPath, addInSearchPattern, SearchOption.TopDirectoryOnly, addInType, filter);
        }
        public int GetComponents(string addInPath, string addInSearchPattern, Type addInType, CompositeLoaderFilter filter)
        {
            return GetComponents(addInPath, addInSearchPattern, SearchOption.TopDirectoryOnly, addInType, filter);
        }
        public int GetComponents(string addInPath, string addInSearchPattern, SearchOption addInSearchOption, Type addInType, CompositeLoaderFilter filter)
        {
            AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
            setup.PrivateBinPath = addInPath;
            setup.ShadowCopyFiles = "false";
            AppDomain m_appDomain = AppDomain.CreateDomain("MyNamespace.CompositeManager", null, setup);
            CompositeManager m_remoteLoader = (CompositeManager)m_appDomain.CreateInstanceFromAndUnwrap(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyAssembly.dll"), "MyNamespace.CompositeManager");
            m_addIns = m_remoteLoader.RemoteGetServices(addInPath, addInSearchPattern, addInSearchOption, addInType, filter);
    #if DEBUG
            DebugLoadedAssemblies();
    #endif
            AppDomain.Unload(m_appDomain);
            return m_addIns.Count;
        }
        public object CreateInstance(string typeName)
        {
            if (!m_addIns.ContainsKey(typeName))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Type {0} was not loaded..", typeName), "typeName");
            MethodInfo method = m_addIns[typeName].GetMethod("GetInstance", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (method != null)
                return method.Invoke(m_addIns[typeName], null);
            else return Activator.CreateInstance(m_addIns[typeName]);
        }
        public object CreateInstance(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type", "Type is null");
            if (!m_addIns.ContainsKey(type.FullName))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Type {0} was not loaded..", type.FullName), "type");
            MethodInfo method = type.GetMethod("GetInstance", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (method != null)
                return method.Invoke(type, null);
            else return Activator.CreateInstance(type);
        }
        public T CreateInstance<T>()
        {
            if (!m_addIns.ContainsKey(typeof(T).FullName))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Type {0} was not loaded..", typeof(T).FullName), "T");
            MethodInfo method = typeof(T).GetMethod("GetInstance", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (method != null)
                return (T)method.Invoke(typeof(T), null);
            else return Activator.CreateInstance<T>();
        }
        public IEnumerable<Type> AvailableServices
        {
            get
            {
                foreach (KeyValuePair<string, Type> item in m_addIns)
                {
                    yield return item.Value;
                }
            }
        }
        public Type[] AvailableTypes
        {
            get
            {
                List<Type> list = new List<Type>();
                foreach (KeyValuePair<string, Type> item in m_addIns)
                    list.Add(item.Value);
                return list.ToArray();
            }
        }
        public T[] GetObjects<T>()
        {
            List<T> list = new List<T>();
            foreach (KeyValuePair<string, Type> item in m_addIns)
                list.Add((T)CreateInstance(item.Value));
            return list.ToArray();
        }
        public object[] AvailableObjects
        {
            get
            {
                List<object> list = new List<object>();
                foreach (KeyValuePair<string, Type> item in m_addIns)
                    list.Add(CreateInstance(item.Value));
                return list.ToArray();
            }
        }
        internal SortedList<string, Type> internal_GetInMemoryServices(Type addInType, CompositeLoaderFilter filter)
        {
            SortedList<string, Type> validAddIns = new SortedList<string, Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        switch (filter)
                        {
                            case CompositeLoaderFilter.ImplementsInterface:
                            if (type.GetInterface(addInType.Name) != null)
                                validAddIns.Add(type.FullName, type);
                            break;
                            case CompositeLoaderFilter.InheritsBaseClass:
                            if (type.BaseType == addInType)
                                validAddIns.Add(type.FullName, type);
                            break;
                        }
                    }
                }
                catch (FileLoadException flex)
                {
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} MyNamespace.CompositeManager: {1}", DateTime.Now.ToString(), flex.Message));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} MyNamespace.CompositeManager: {1}", DateTime.Now.ToString(), ex.Message));
                }
            }
            return validAddIns;
        }
        internal SortedList<string, Type> RemoteGetServices(string addInPath, string addInSearchPattern, SearchOption addInSearchOption, Type addInType, CompositeLoaderFilter filter)
        {
            string[] files = Directory.GetFiles(addInPath, addInSearchPattern, addInSearchOption);
            SortedList<string, Type> validAddIns = new SortedList<string, Type>();
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    if (String.CompareOrdinal(addInPath, file) != 0)
                    {
                        try
                        {
                            Assembly assembly = Assembly.LoadFrom(file);
                            Type[] types = assembly.GetTypes();
                            foreach (Type type in types)
                            {
                                switch (filter)
                                {
                                    case CompositeLoaderFilter.ImplementsInterface:
                                    if (type.GetInterface(addInType.Name) != null)
                                        validAddIns.Add(type.FullName, type);
                                    break;
                                    case CompositeLoaderFilter.InheritsBaseClass:
                                    if (type.BaseType == addInType)
                                        validAddIns.Add(type.FullName, type);
                                    break;
                                }
                            }
                        }
                        catch (FileLoadException flex)
                        {
                            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} MyNamespace.CompositeManager: {1}", DateTime.Now.ToString(), flex.Message));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} MyNamespace.CompositeManager: {1}", DateTime.Now.ToString(), ex.Message));
                        }
                    }
                }
            }
    #if DEBUG
            DebugLoadedAssemblies();
    #endif
            return validAddIns;
        }
    #if DEBUG
        internal void DebugLoadedAssemblies()
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                //Debug.WriteLine(string.Format("Domain: {0} Assembly: {1}", AppDomain.CurrentDomain.FriendlyName, a.FullName));
            }
        }
    #endif
    }
