    if(!string.IsNullOrWhiteSpace(qual2)&!string.IsNullOrWhiteSpace(clg2)&!string.IsNullOrWhiteSpace(mark2)&!string.IsNullOrWhiteSpace(year2))                             
              {
                cmd.Parameters.Add("@Qualification2", SqlDbType.VarChar).Value = qual2.Length > 0 ? qual2 : (object)DBNull.Value;
                cmd.Parameters.Add("@College2", SqlDbType.VarChar).Value = clg2.Length > 0 ? clg2 : (object)DBNull.Value;
                cmd.Parameters.Add("@Mark2", SqlDbType.Int).Value = mark2.Length > 0 ? mark2 : (object)DBNull.Value;
                cmd.Parameters.Add("@Year2", SqlDbType.VarChar).Value =year2.Length > 0 ? year2 : (object)DBNull.Value;
                conn.nonquery(cmd);
              }
