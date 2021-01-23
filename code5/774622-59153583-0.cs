    public static bool Insert<T>(T entity)
            {
                var tableName = entity.GetType().CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == nameof(TableAttribute))?.ConstructorArguments?.FirstOrDefault().Value as string;
                if (string.IsNullOrEmpty(tableName))
                    throw new Exception($"Cannot save {entity.GetType().Name}. Database models should have [Table(\"tablename\")] attribute.");
                DBSchema.TryGetValue(tableName.ToLower(), out var fields);
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
    
                    var sql = $"INSERT INTO [{tableName}] (";
                    foreach (var field in fields.Where(x => x != "id")) 
                    {
                        sql += $"[{field}]"+",";
                    }
                    sql = sql.TrimEnd(',');
                    sql += ")";
                    sql += " VALUES (";
                    foreach (var field in fields.Where(x => x != "id"))
                    {
                        sql += "@"+field + ",";
                    }
                    sql = sql.TrimEnd(',');
                    sql += ")";
    
                    var affectedRows = con.Execute(sql, entity);
                    return affectedRows > 0;
                }
            }
