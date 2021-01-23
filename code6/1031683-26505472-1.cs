    public static int runRead(string Query, object Tick) {
        checkConnection();
        try {
            return Convert.ToInt32(new MySqlCommand(Query + " LIMIT 1", dbConnection).ExecuteScalar());
        } catch {
            return 0;
        }
    }
