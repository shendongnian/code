    [Export(typeof(IEnumerable<>))]
    public class IntegerCollection: List<int>
    {
    }
    [ModuleExport(typeof(TestModule))]
    public class TestModule : Microsoft.Practices.Prism.Modularity.IModule
    {
        [Import]
        public IEnumerable<int> Integers
        {
            get { return m_Integers; }
            set { m_Integers = value; }
        } private IEnumerable<int> m_Integers;
        public void Initialize()
        {
        }
    }
