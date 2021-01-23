    public static List<EmpData> getData(int carrierID)
                                        ^^^^^^^^^^^^^
    {
        List<EmpData> list = new List<EmpData>();
        StringBuilder sqlString = new StringBuilder();
        sqlString.Append("SELECT e.*, c.Carrier ");
        sqlString.Append("FROM Employee e, CellCarrier c ");
        sqlString.Append(" WHERE e.CarrierID = @CarrierID ");
        sqlString.Append("  AND e.CarrierID = c.CarrierID");
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sqlString.ToString();
        cmd.Parameters.AddWithValue("CarrierID", carrierID);
                                                 ^^^^^^^^^
