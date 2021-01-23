    class MainForm : Form
    {
        private readonly List<Factory> topLevelFactoryActivities;
        
        public MainForm()
        {
            // ... other code
            topLevelFactoryActivities = LoadTopLevelFactoryActivities();
        }
        private IEnumerable<Factory> LoadTopLevelFactoryActivities()
        {
            var factories = new List<Factory>();
            
            // TODO: Load the factories, e.g. from a database or a file.
            // You can load all the child objects for each factory here as well,
            // or wait until later ("lazy-loading") if you want to.
            // NOTE: If this becomes complex, you can move the LoadTopLevelFactoryActivities()
            // method to its own class, which then becomes your "data access layer" (DAL).
            
            return factories;
        }
    }
