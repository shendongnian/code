    using Dapper;
    using System.Data;
    using System.Data.SqlClient;
    
    public static int ExecuteOutputParam
                (this IDbConnection conn, string sql, object args)
            {
                // Stored procedures with output parameter require
                // dynamic params. This assumes the OUTPUT parameter in the
                // SQL is an INTEGER named @id.
                var p = new DynamicParameters();
                p.Add("id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var properties = args.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var key = prop.Name;
                    var value = prop.GetValue(args);
                    p.Add(key, value);
                }
                conn.Execute(sql, p);
                int id = p.Get<int>("id");
                return id;
            }
