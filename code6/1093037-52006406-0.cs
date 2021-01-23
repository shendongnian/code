     public static class MongoExtensions
    {
        public static IFindFluent<T, T> SetFields<T>(this IFindFluent<T, T> query, params string[] fields)
        {
            if ( fields == null || fields.Length == 0 )
            {
                return query;
            }
            var project = Builders<T>.Projection.IncludeAll<T>(fields);
            return query.Project<T>(project);
        }
        public static ProjectionDefinition<T> IncludeAll<T>(this ProjectionDefinitionBuilder<T> projection,
            params string[] fields)
        {
            ProjectionDefinition<T> project = null;
            foreach (string columnName in fields)
            {
                if (project == null)
                {
                    project = Builders<T>.Projection.Include(columnName);
                }
                else
                {
                    project = project.Include(columnName);
                }
            }
            return project;
        }
    }
