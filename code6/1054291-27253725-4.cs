    public class ParameterValueRepository : IParameterValueRepository
    {
        private readonly OrmLiteConnectionFactory _dbFactory;
    
        public ParameterValueRepository(OrmLiteConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
    }
