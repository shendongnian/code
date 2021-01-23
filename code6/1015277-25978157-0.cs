    public DataAccessClass: IWorkOnStuff
    {
        public Func<DataEntities> DataAccessFactory { get; internal set; }
    
        private string ConnectionString;
        public PortailPatientManagerImplementation(string connectionString)
        {
            ConnectionString = connectionString;
            DataAccessFactory = () => { return new DataEntities(ConnectionString); };
        }
    
        /* interface methods */
    
        public IEnumerable<Stuff> GetTheStuff(SomeParameters params)
        {
            using (var context = DataAccessFactory())
            {
                 return context.Stuff.Where(stuff => params.Match(stuff));
            }
        }
    }
