    public class ExtraMoveDataSet
    {
        string connectionString = @"Data Source=sampleDB; Initial Catalog=test; User Id=sa; Password=test";
        public IEnumerable<ExtraMoveModel> extraMove(DateTime dateFrom, DateTime dateTo)
        {
            var tempList = new List<ExtraMoveModel>();
            //string connectionString = @"Data Source=nsqltest; Initial Catalog=sparcsn4; User Id=sa; Password=lo02Nova";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AGCT_ServiceEventReport", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            conn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var temp = new ExtraMoveModel();
                    temp.EventType = dr["event_type"].ToString();
                    temp.EventCount = Convert.ToInt32(dr["CNT"]);
                    temp.Num20 = Convert.ToInt32(dr["NUM20"]);
                    temp.Num40 = Convert.ToInt32(dr["NUM40"]);
                    temp.Num45 = Convert.ToInt32(dr["NUM45"]);
                    temp.TEU = Convert.ToInt32(dr["TEU"]);
                    temp.Cargo = float.Parse(dr["Cargo"].ToString(),new CultureInfo("hr-HR"));
                    temp.Tare = float.Parse(dr["Tare"].ToString(),new CultureInfo("hr-HR"));
                    temp.Total = float.Parse(dr["Total"].ToString(),new CultureInfo("hr-HR"));
                    tempList.Add(temp);
                }
            }
            conn.Close();
            return tempList;
        }
