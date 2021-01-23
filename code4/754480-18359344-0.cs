    public class SqlRegionInterceptor : EmptyInterceptor, IInterceptor
    {
    
        NHibernate.SqlCommand.SqlString IInterceptor.OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            return sql.Replace("Region=0", "Region<>0");
        }
    }
