    private static MemoryStream GetStatement(OracleConnection con, int loginId, string session, string ip, string acNo, DateTime frmDate, DateTime toDate)
        {
            var memoryStream = new MemoryStream();
            using (
                var oraQuery =
                    new OracleCommand(
                        @"SELECT statement_file from user_account_statement where login_id=:1 and session_key=:2" +
                            "and ipaddress=:3 and account_number=:4 and from_date=:5 and to_date=:6" +
                            " and status='closed'", con))
            {
                oraQuery.BindByName = true;
                oraQuery.Parameters.Add(":1", OracleDbType.Int32).Value = loginId;
                oraQuery.Parameters.Add(":2", OracleDbType.NVarchar2).Value = session;
                oraQuery.Parameters.Add(":3", OracleDbType.NVarchar2).Value = ip;
                oraQuery.Parameters.Add(":4", OracleDbType.NVarchar2).Value = acNo;
                oraQuery.Parameters.Add(":5", OracleDbType.Date).Value = frmDate;
                oraQuery.Parameters.Add(":6", OracleDbType.Date).Value = toDate;
                using (var oraQueryResult = oraQuery.ExecuteReader())
                    if (oraQueryResult != null)
                    {
                        while (oraQueryResult.Read())
                        {
                            var blob = new Byte[(oraQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                            oraQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                            memoryStream.Write(blob, 0, blob.Length);
                        }
                    }
            }
            return memoryStream;
        }
 
