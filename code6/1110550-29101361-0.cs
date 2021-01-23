            using (var ctx = new StOflowContext())
            {
                ctx.Database.Connection.Open();
                using (var command = ctx.Database.Connection.CreateCommand())
                {
                    command.CommandText = "StoredProcedureName";
                    command.CommandType = CommandType.StoredProcedure;
                    DbParameter param = command.CreateParameter();
                    param.ParameterName = "@paramName";
                    param.DbType = DbType.String;
                    param.Direction = ParameterDirection.Input;
                    param.Value = "Vikash";
                    
                    command.Parameters.Add(param);
                    using (var reader = command.ExecuteReader())
                    
                    { 
                        while(reader.Read())
                        {
                        }
                    }
                }
            }
