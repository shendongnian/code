    public partial class Epl2CommandFactory
    {
        #region Singelton pattern
        private static volatile Epl2CommandFactory m_instance;
        private static object m_syncRoot = new object();
        public static Epl2CommandFactory Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_syncRoot)
                    {
                        if (m_instance == null)
                        {
                            m_instance = new Epl2CommandFactory();
                        }
                    }
                }
                return m_instance;
            }
        }
        #endregion
        #region Constructor
        private Epl2CommandFactory()
        {
            m_generalCommands = new Dictionary<string, Type>();
            Initialize();
        }
        #endregion
        #region Variables
        private Dictionary<string, Type> m_generalCommands;
        private Assembly m_asm;
        #endregion
        #region Helpers
        private void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(GetType());
            Type[] allTypes = asm.GetTypes();
            foreach (Type type in allTypes)
            {
                // Only scan classes that are not abstract
                if (type.IsClass && !type.IsAbstract)
                {
                    // If a class implements the IEpl2FactoryProduct interface,
                    // which allows retrieval of the product class key...
                    Type iEpl2FactoryProduct = type.GetInterface("IEpl2GeneralFactoryProduct");
                    if (iEpl2FactoryProduct != null)
                    {
                        // Create a temporary instance of that class...
                        object inst = asm.CreateInstance(type.FullName);
                        if (inst != null)
                        {
                            // And generate the product classes key
                            IEpl2GeneralFactoryProduct keyDesc = (IEpl2GeneralFactoryProduct)inst;
                            string key = keyDesc.GetFactoryKey();
                            m_generalCommands.Add(key, type);
                            inst = null;
                        }
                    }
                }
            }
            m_asm = asm;
        }
        #endregion
        #region Methods
        public IEpl2Command CreateEpl2Command(string command)
        {
            if (command == null)
                throw new NullReferenceException("Invalid command supplied, must be " +
                                                 "non-null.");
            
            Type type;
            if (!m_generalCommands.TryGetValue(command.Substring(0, 2), out type))
                m_generalCommands.TryGetValue(command.Substring(0, 1), out type);
            if (type != default(Type))
            {
                object inst = m_asm.CreateInstance(type.FullName, true,
                                                   BindingFlags.CreateInstance,
                    null, null, null, null);
                if (inst == null)
                    throw new NullReferenceException("Null product instance.  " +
                         "Unable to create necessary product class.");
                IEpl2Command prod = (IEpl2Command)inst;
                prod.CommandString = command;
                return prod;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
