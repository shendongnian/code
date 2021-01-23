    public IEnumerable<TEntity> RunFullTextContainsQuery(Expression <Func <TEntity, object>> property, string search)
            {
                if ( string.IsNullOrWhiteSpace(search))
                {
                    return Enumerable.Empty<TEntity>();
                }
        
                var unaryExpression = property.Body as UnaryExpression;
        
                var memberExpression = property.Body as MemberExpression ?? (unaryExpression != null ? unaryExpression.Operand as MemberExpression : null );
        
                if (memberExpression == null)
                {
                    throw new Exception( string.Format( "Invalid lambda expression: '{0}'.", property));
                }
        
                var query = string.Format( "SELECT * FROM {0} WHERE CONTAINS( {1}, @search)", GetTableName(), memberExpression.Member.Name);
        
                return _context.Database.SqlQuery<TEntity>(query, new SqlParameter("@search" , search));
            }
        
            private string GetTableName()
            {
                var objectContext = (( IObjectContextAdapter) _context).ObjectContext;
                var sql = objectContext.CreateObjectSet<TEntity>().ToTraceString();
                var regex = new Regex( @"FROM\s+(?<table>.+)\s+AS" );
                var match = regex.Match(sql);
        
                return match.Groups[ "table"].Value;
            }
