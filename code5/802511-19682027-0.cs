     /// <summary>
        /// Tracea la qry de BD de IQueryable/>
        /// </summary>
        /// <typeparam name="TEntity">Tipo de IQueryable</typeparam>
        /// <param name="query">IQueryable generate the query</param>
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
                    sb.AppendLine("Parmámetros de la qry:");
                    sb.AppendLine("--------------------------------------------------------------");
                    sb.AppendLine("      Name          |        Type        |       Value        ");
                    sb.AppendLine("--------------------------------------------------------------");
                    foreach (var param in objQuery.Parameters) 
                    {
                        sb.AppendFormat("{0, -20}|{1, -20}|{2, -20}{3}", param.Name, param.ParameterType.ToString(), param.Value, Environment.NewLine);
                    }
                    sb.AppendLine();
                }
                string qryParcial = objQuery.ToTraceString();
                objQuery.Parameters.ToList().ForEach(p => qryParcial = qryParcial.Replace(":" + p.Name, p.Value.ToString()));
                sb.AppendLine(qryParcial);
            }
            // replace 
            return sb.ToString();
        }
