     /// <summary>
        /// Traces IQueryable's DB query />
        /// </summary>
        /// <typeparam name="TEntity">IQueryable type</typeparam>
        /// <param name="query">The IQueryable query</param>
        /// <returns>Query</returns>
        public static string ToTraceString<TEntity>(this IQueryable<TEntity> query)
        {
            StringBuilder sb = new StringBuilder();
            var objQuery = query as ObjectQuery<TEntity>;
            if (objQuery != null)
            {
                sb.AppendLine();
                if(objQuery.Parameters.Count > 0)
                {
                    sb.AppendLine("Query parameters:");
                    sb.AppendLine("--------------------------------------------------------------");
                    sb.AppendLine("      Name          |        Type        |       Value        ");
                    sb.AppendLine("--------------------------------------------------------------");
                    foreach (var param in objQuery.Parameters) 
                    {
                        sb.AppendFormat("{0, -20}|{1, -20}|{2, -20}{3}", param.Name, param.ParameterType.ToString(), param.Value, Environment.NewLine);
                    }
                    sb.AppendLine();
                }
                string partialQuery = objQuery.ToTraceString();
                objQuery.Parameters.ToList().ForEach(p => partialQuery = partialQuery.Replace(":" + p.Name, p.Value.ToString()));
                sb.AppendLine(partialQuery);
            }
            // replace 
            return sb.ToString();
        }
