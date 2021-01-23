    public class OracleRepository 
    {
        const string User = "*";
        const string Pass = "*";
        const string Source = "*";
        const string ConnectionString = "User Id=" + User + ";" + "Password=" + Pass + ";" + "Data Source=" + Source + ";";
        public static  IDbConnection GetOpenIDbConnection(){
            //Not really important; however, for this example I Was using an oracle connection
            return new OracleConnection(ConnectionString).OpenConnection(); 
        }
        protected IEnumerable<String> GetEntryPropertyNames(Type type){
            foreach (var propInfo in type.GetProperties())
                yield return propInfo.Name;
        }
    }
     public class OracleRepository<T> : OracleRepository,IDisposable, IRepository<T> where T :  IRepositoryEntry, new()
        {
            #region Public EventHandlers
            public event EventHandler<RepositoryOperationEventArgs> InsertEvent;
            public event EventHandler<RepositoryOperationEventArgs> UpdateEvent;
            public event EventHandler<RepositoryOperationEventArgs> DeleteEvent;
            #endregion
            #region Public Properties
            public IList<String> PrimaryKeys{ get { return primaryKeys.AsReadOnly(); } }
            public IList<String> Properties { get; private set; }
            public String InsertText { get; private set; }
            public String UpdateText { get; private set; }
            public String DeleteText { get; private set; }
            public String SelectText { get; private set; }
            #endregion
            #region Private fields
            List<String> primaryKeys;
            IDbConnection connection;
            IDbTransaction transaction;
            bool disposed;
            #endregion
            #region Constructor(s)
            public OracleRepository()
            {
                primaryKeys = new List<String>(new T().GetPrimaryKeys());
                Properties = new List< String>(GetEntryPropertyNames(typeof(T))).AsReadOnly();
                SelectText = GenerateSelectText();
                InsertText = GenerateInsertText();
                UpdateText = GenerateUpdateText();
                DeleteText = GenerateDeleteText();
                connection = GetOpenIDbConnection();
            }
            #endregion
            #region Public Behavior(s)
            public void StartTransaction() 
            {
                if (transaction != null)
                    throw new InvalidOperationException("Transaction is already set. Please Rollback or commit transaction");
                transaction = connection.BeginTransaction();
            }
            public void CommitTransaction() 
            {
                using(transaction)
                    transaction.Commit();
                transaction = null;
            }
            public void Rollback() 
            {
                using (transaction)
                    transaction.Rollback();
                transaction = null;
            }
            public void Insert(IDbConnection connection, T entry)
            {
                connection.NonQuery(InsertText, Properties.Select(p => typeof(T).GetProperty(p).GetValue(entry)).ToArray());
                if (InsertEvent != null) InsertEvent(this, new OracleRepositoryOperationEventArgs() { Entry = entry, IsTransaction = (transaction != null) });
            }
            public void Update(IDbConnection connection, T entry)
            {
                connection.NonQuery(UpdateText, Properties.Where(p => !primaryKeys.Any(k => k == p)).Concat(primaryKeys).Select(p => typeof(T).GetProperty(p).GetValue(entry)).ToArray());
                if (UpdateEvent != null) UpdateEvent(this, new OracleRepositoryOperationEventArgs() { Entry = entry, IsTransaction = (transaction != null) });
            }
            public void Delete(IDbConnection connection, Predicate<T> predicate)
            {
                foreach (var entry in  RetrieveAll(connection).Where(new Func<T, bool>(predicate)))
                {
                    connection.NonQuery(DeleteText, primaryKeys.Select(p => typeof(T).GetProperty(p).GetValue(entry)).ToArray());
                    if (DeleteEvent != null) DeleteEvent(this, new OracleRepositoryOperationEventArgs() { Entry = null, IsTransaction = (transaction != null) });
                }
            }
            public T Retrieve(IDbConnection connection, Predicate<T> predicate)
            {
                return RetrieveAll(connection).FirstOrDefault(new Func<T, bool>(predicate));
            }
            public bool Exists(IDbConnection connection, Predicate<T> predicate)
            {
                return RetrieveAll(connection).Any(new Func<T, bool>(predicate));
            }
            public IEnumerable<T> RetrieveAll(IDbConnection connection)
            {
                return connection.Query(SelectText).Tuples.Select(p => RepositoryEntryBase.FromPlexQueryResultTuple(new T(), p) as T);
            }
            #endregion
            #region IRepository Behavior(s)
            public void Insert(T entry)
            {
                using (var connection = GetOpenIDbConnection())
                    Insert(connection, entry);
            }
            public void Update(T entry)
            {
                using (var connection = GetOpenIDbConnection())
                    Update(connection, entry);
            }
     
            public void Delete(Predicate<T> predicate)
            {
                using (var connection = GetOpenIDbConnection())
                    Delete(connection, predicate);
            }
    
            public T Retrieve(Predicate<T> predicate)
            {
                using (var connection = GetOpenIDbConnection())
                    return Retrieve(connection, predicate);         
            }
            public bool Exists(Predicate<T> predicate)
            {
                using (var connection = GetOpenIDbConnection())
                    return Exists(predicate);
            }
    
            public IEnumerable<T> RetrieveAll()
            {
                using (var connection = GetOpenIDbConnection())
                    return RetrieveAll(connection);
            }
            #endregion
            #region IDisposable Behavior(s)
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion
            #region Protected Behavior(s)
            protected virtual void Dispose(Boolean disposing)
    
            {
                if(disposed)
                    return;
                if (disposing)
                {
                    if(transaction != null)
                        transaction.Dispose();
                    if(connection != null)
                        connection.Dispose();
                }
                disposed = true;
            }
            #endregion
            #region Private Behavior(s)
            String GenerateInsertText()
            {
                String statement = "INSERT INTO {0}({1}) VALUES ({2})";
                //Do first entry here becasse its unique input.
                String columnNames = Properties.First();
    
                String delimiter = ", ";
                String bph = ":a";
    
                String placeHolders = bph + 0;
    
                //Start @ 1 since first entry is already done
                for (int i = 1; i < Properties.Count; i++)
                {
                    columnNames += delimiter + Properties[i];
                    placeHolders += delimiter + bph + i;
                }
    
                statement = String.Format(statement, typeof(T).Name, columnNames, placeHolders);
                return statement;
            }
            String GenerateUpdateText()
            {
                String bph = ":a";
                String cvpTemplate = "{0} = {1}";
                String statement = "UPDATE {0} SET {1} WHERE {2}";
    
                //Can only set Cols that are not a primary Keys, Get those Columns
                var Settables = Properties.Where(p => !PrimaryKeys.Any(k => k == p)).ToList();
    
                String cvp = String.Format(cvpTemplate, Settables.First(), bph + 0);
                String condition = String.Format(cvpTemplate, PrimaryKeys.First(), bph + Settables.Count);
    
                //These are the values to be set | Start @ 1 since first entry is done above.
                for (int i = 1; i < Settables.Count; i++)
                    cvp += ", " + String.Format(cvpTemplate, Settables[i], bph + i);
    
                //This creates the conditions under which the values are set. | Start @ 1 since first entry is done above.
                for (int i = Settables.Count + 1; i < Properties.Count; i++)
                    condition += " AND " + String.Format(cvpTemplate, PrimaryKeys[i - Settables.Count], bph + i);
    
                statement = String.Format(statement, typeof(T).Name, cvp, condition);
                return statement;
            }
            String GenerateDeleteText()
            {
                String bph = ":a";
                String cvpTemplate = "{0} = {1}";
                String statement = "DELETE FROM {0} WHERE {1}";
                String condition = String.Format(cvpTemplate, PrimaryKeys.First(), bph + 0);
    
                for (int i = 1; i < PrimaryKeys.Count; i++)
                    condition += " AND " + String.Format(cvpTemplate, PrimaryKeys[i], bph + i);
    
                statement = String.Format(statement, typeof(T).Name, condition);
                return statement;
            }
            String GenerateSelectText()
            {
                String statement = "SELECT * FROM {0}";
                statement = String.Format(statement, typeof(T).Name);
                return statement;
            }
            #endregion
            #region Destructor
            ~OracleRepository()
            {
                Dispose(false);
            }
            #endregion
        }
