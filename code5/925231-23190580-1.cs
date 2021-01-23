    SqlParameter param = new SqlParameter();
                 param.ParameterName = "@Isstatus";
                 param.Value = Isstatus;
                 param.DbType = System.Data.DbType.Boolean
                 cmd.Parameters.Add(param);
