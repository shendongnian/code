     public static class MultipleResultSets
    {
        #region Public Methods
        public static MultipleResultSetWrapper MultipleResults(this DbContext db,string query,IEnumerable<SqlParameter> parameters=null) => new MultipleResultSetWrapper(db: db,query: query,parameters: parameters);
        #endregion Public Methods
        #region Public Classes
        public class MultipleResultSetWrapper
        {
            #region Public Fields
            public List<Func<DbDataReader,IEnumerable>> _resultSets;
            #endregion Public Fields
            #region Private Fields
            private readonly IObjectContextAdapter _Adapter;
            private readonly string _CommandText;
            private readonly DbContext _db;
            private readonly IEnumerable<SqlParameter> _parameters;
            #endregion Private Fields
            #region Public Constructors
            public MultipleResultSetWrapper(DbContext db,string query,IEnumerable<SqlParameter> parameters = null)
            {
                _db = db;
                _Adapter = db;
                _CommandText = query;
                _parameters = parameters;
                _resultSets = new List<Func<DbDataReader,IEnumerable>>();
            }
            #endregion Public Constructors
            #region Public Methods
            public MultipleResultSetWrapper AddResult<TResult>()
            {
                _resultSets.Add(OneResult<TResult>);
                return this;
            }
            public List<IEnumerable> Execute()
            {
                var results = new List<IEnumerable>();
                using(var connection = _db.Database.Connection)
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = _CommandText;
                    if(_parameters?.Any() ?? false) { command.Parameters.AddRange(_parameters.ToArray()); }
                    using(var reader = command.ExecuteReader())
                    {
                        foreach(var resultSet in _resultSets)
                        {
                            results.Add(resultSet(reader));
                        }
                    }
                    return results;
                }
            }
            #endregion Public Methods
            #region Private Methods
            private IEnumerable OneResult<TResult>(DbDataReader reader)
            {
                var result = _Adapter
                    .ObjectContext
                    .Translate<TResult>(reader)
                    .ToArray();
                reader.NextResult();
                return result;
            }
            #endregion Private Methods
        }
        #endregion Public Classes
    }
