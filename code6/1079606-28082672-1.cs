    SqlParameter moFrom1Param = new SqlParameter("@MoFrom1", expairydate == null 
               ? DBNull.Value : expairydate);
                moFrom1Param.IsNullable = true;
                moFrom1Param.Direction = ParameterDirection.Input;
                moFrom1Param.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(moFrom1Param);
