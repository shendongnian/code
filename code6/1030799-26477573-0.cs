    using (OracleConnection conn = new OracleConnection(BD_CONN_STRING))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("create global temporary table t1(id number(9))", conn))
                {
                    // actually this should execute once only
                    cmd.ExecuteNonQuery();
                }
                using (OracleCommand cmd = new OracleCommand("insert into t1 values (1)", conn)) {
                    cmd.ExecuteNonQuery();
                }
                // customer table is a permenant table 
                using (OracleCommand cmd = new OracleCommand("select c.id from customer c, t1 tmp1 where c.id=tmp1.id", conn)) {
                    cmd.ExecuteNonQuery();
                }
            }
