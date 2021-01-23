    public class TenantInterceptor : EmptyInterceptor
        {
            private ISession _session;
    
            public override void SetSession(ISession session)
            {
                _session = session;
                base.SetSession(session);
            }
    
            public override object GetEntity(string entityName, object id)
            {
                object entity = base.GetEntity(entityName, id);
    
                if (entity != null && entity.GetType().IsAssignableFrom(typeof(User)))
                {
                    var filter = _session.GetEnabledFilter("Tenant") as FilterImpl;
    
                    if (filter != null)
                    {
                        var filterValue = filter.Parameters["name"];
                        var user = entity as User;
                        if (!user.Tenant.Equals(filterValue))
                            return null;
                    }
                }
                return entity;
            }
    
            
            public override SqlString OnPrepareStatement(SqlString sql)
            {
                if (sql.ToString().EndsWith("FROM \"User\" user0_ WHERE user0_.Id=?"))
                {
                    var filter = _session.GetEnabledFilter("Tenant") as FilterImpl;
                    if (filter != null)
                    {
                        var filterValue = filter.Parameters["name"];
                        sql = sql.Append(string.Format(" And user0_.Tenant = '{0}'",filterValue));    
                    }
                }
                return base.OnPrepareStatement(sql);
            }
        }
