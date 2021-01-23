    public static List<IGraphNode> MergeUser(User user)
    {
         var sb = new StringBuilder();
         sb.AppendLine("MERGE user:User { Id: '{0}' }");
         sb.AppendLine("RETURN user");
         string commandQuery = sb.ToString();
         commandQuery = string.Format(commandQuery, user.UserId);
         GraphClient graphClient = GetNeo4jGraphClient();
         var cypher = new CypherFluentQueryCreator(graphClient, new CypherQueryCreator(commandQuery), new Uri(Configuration.GetDatabaseUri()));
         var resulttask = cypher.ExecuteGetCypherResults<GraphNode>();
         var graphNodeResults = resulttask.Result.ToList().Select(gn => (IGraphNode)gn).ToList();
         return graphNodeResults;
    }
