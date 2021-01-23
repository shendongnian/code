     public class DefaultOrderInterceptor : IDbCommandTreeInterceptor
        {
            public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
            {
                if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
                {
                    var queryCommand = interceptionContext.Result as DbQueryCommandTree;
     
                    if (queryCommand != null)
                    {
                        var newQuery = queryCommand.Query.Accept(new DefaultOrderVisitor());
                        interceptionContext.Result = new DbQueryCommandTree(queryCommand.MetadataWorkspace,
                            queryCommand.DataSpace, newQuery);
                    }
                }
            }
        }
