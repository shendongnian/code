    public static DataTable DOACases(DateTime doa, int days)
        {
            try
            {
                DataTable table = new DataTable();
                string sqlText = "SELECT * " +
                                 "FROM [Case] " +
                                 "WHERE ABS((DATEDIFF(DAY, [DateAccident], @Date))) < @Days;";
                SqlCommand sqlCom = new SqlCommand(sqlText);
                sqlCom.Parameters.Add("@Date", SqlDbType.Date).Value = doa;
                sqlCom.Parameters.Add("@Days", SqlDbType.Int).Value = days;
                table = Express.GetTable(sqlCom);
                return table;
            }
            catch (Exception eX)
            {
                throw new Exception("Case: DOACases(Date)" + Environment.NewLine + eX.Message);
            }
        }
