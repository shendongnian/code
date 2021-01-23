    // upside: just one line in child class
    // downside: a little harder for external callers, with a little less type safety
    // downside: as written, requires child class to have parameterless constructor
    partial class SomeDataContext : DataContextBase
    {
        protected override string DatabaseFileInternal { get { return "blablabla.mdf"; } }
    }
    abstract class DataContextBase
    {
        protected abstract string DatabaseFileInternal { get; }
        private string ConnectionString
        {
            get
            {
                return string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", DatabaseFileInternal);
            }
        }
        public static T GetInstance<T>() where T : DataContextBase, new()
        {
            using (var tInst = new T())
                return (T)Activator.CreateInstance(typeof(T), tInst.ConnectionString);
        }
    }
    // e.g. using (var context = DataContextBase.GetInstance<SomeDataContext>())
