    public class GenericDao<T,M> : DaoBase where M :T, IGenericEntity<T>, new()
        {
    
            #region singleton
    
            private M Instance
            {
                get
                {
                    if (_inst == null)
                    {
                        _inst = new M();
                    }
                    return _inst;
                }
                set {
                    _inst = value;
                }
            }
            private M _inst;
    
            #endregion
    
            #region Constructor
            /// <summary>
            /// Constructeur.
            /// </summary>
            public GenericDao(): base()
            {
    
                this.DataSourceName = Instance.GetDataSourceName();
    
                base.InitializeConnection();
    
            }
            #endregion
    
            #region Public Methods
    
            /// <summary>
            /// Get First Element
            /// </summary>
            /// <param name="filter"></param>
            /// <returns></returns>
            public T Get(T filter)
            {
                var parameters = SqlHelperParameterCache.GetSpParameterSet(ConnectionString, Instance.GetSearchProc());            
                Instance.FillParams(filter,parameters);
                using (IDataReader reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, Instance.GetSearchProc(), parameters))
                    if (reader.Read())
                    {
                        var item = new M();
                        item.FillEntity(reader);
                        return item;
                    }
                return default(T);
            }
    
            /// <summary>
            /// Lists All records
            /// </summary>
            /// <returns></returns>
            public List<T> List()
            {
                var list = new List<T>();
                using (IDataReader reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, Instance.GetSearchProc()))
                    while (reader.Read())
                    {
                        var item = new M();
                        item.FillEntity(reader);
                        list.Add(item);
                    }
                return list;
            }
    
            /// <summary>
            /// Searchs Elements
            /// </summary>
            /// <param name="filter"></param>
            /// <returns></returns>
            public List<T> Search(T filter,PagingParameters paging)
            {
                var parameters = SqlHelperParameterCache.GetSpParameterSet(ConnectionString, Instance.GetSearchProc());
                Instance.FillParams(filter,parameters,paging);
                var list = new List<T>();
                using (IDataReader reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.StoredProcedure, Instance.GetSearchProc(), parameters))
                    while (reader.Read())
                    {
                        var item = new M();
                        item.FillEntity(reader);
                        list.Add(item);
                    }
                return list;
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Item"></param>
            /// <returns></returns>
            public int Insert(T Item)
            {
                var ret = 0;
                throw new NotImplementedException();
                return ret;
            }
    
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Item"></param>
            /// <returns></returns>
            public int Update(T Item)
            {
                var ret = 0;
                throw new NotImplementedException();
                return ret;
            }
    
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Item"></param>
            /// <returns></returns>
            public int Delete(T Item)
            {
                var ret = 0;
                throw new NotImplementedException();
                return ret;
            }
            #endregion
        }
    
       public interface IGenericEntity<T>
        {
            void FillEntity(IDataReader reader);
            void FillParams(T filter,SqlParameter[] parameters);
            void FillParams(T filter,SqlParameter[] parameters, PagingParameters paging);
            string GetSearchProc();
            string GetDataSourceName();
    
        }
