       public class LinqProvider<T>
        {
            static readonly FieldInfo INTERNAL_QUERY_FIELD;
            static readonly FieldInfo QUERYSTATE_FIELD;
    
            static LinqProvider()
            {
                INTERNAL_QUERY_FIELD = typeof(DbQuery<T>).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_internalQuery"));
                QUERYSTATE_FIELD = typeof(System.Data.Entity.Core.Objects.ObjectQuery<>).BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "_state");
            }
    
            public IQueryable<T> QueryContext { get; set; }
    
            InternalQuery _InternalQueryContext;
            public InternalQuery InternalQueryContext
            {
                get
                {
                    if (_InternalQueryContext == null)
                    {
                        _InternalQueryContext = new InternalQuery();
    
                        if (QueryContext is DbQuery<T>)
                        {
                            var internalQuery = INTERNAL_QUERY_FIELD.GetValue(QueryContext);
    
                            var objectQueryField = internalQuery.GetType().GetProperties().FirstOrDefault(f => f.Name.Equals("ObjectQuery"));
    
                            _InternalQueryContext.ObjectQueryContext = objectQueryField.GetValue(internalQuery) as System.Data.Entity.Core.Objects.ObjectQuery<T>;
                        }
                        else if (QueryContext is System.Data.Entity.Core.Objects.ObjectQuery<T>)
                        {
                            _InternalQueryContext.ObjectQueryContext = (QueryContext as System.Data.Entity.Core.Objects.ObjectQuery<T>);
                        }
                    }
    
                    return _InternalQueryContext;
                }
            }
    
            public LinqProvider(IQueryable<T> queryContext)
            {
                QueryContext = queryContext;
            }
    
            public class InternalQuery
            {
                public System.Data.Entity.Core.Objects.ObjectQuery<T> ObjectQueryContext { get; set; }
    
                public string ToTraceString(IDictionary<string, object> Parameters = null)
                {
                    var state = QUERYSTATE_FIELD.GetValue(ObjectQueryContext);
    
                    var mi = state.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "GetExecutionPlan");
    
                    mi.Invoke(state, new object[] { null });
    
                    var paramState = state.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "_parameters");
    
                    if (paramState != null)
                    {
                        System.Data.Entity.Core.Objects.ObjectParameterCollection col = paramState.GetValue(state) as System.Data.Entity.Core.Objects.ObjectParameterCollection;
    
                        if (col != null && Parameters != null)
                        {
                            foreach (var item in col)
                            {
                                Parameters.Add(item.Name, item.Value);
                            }
                        }
                    }
    
                    return ObjectQueryContext.ToTraceString();
                }
            }
        }
