    DateTime startDate = new DateTime(2015, 2, 1);
    DateTime endDate = new DateTime(2015, 7, 1, 23, 59, 59); // add time to Include all day
    string cmdText = @"SELECT * FROM RequestsQueueObjects 
                       WHERE PODObjectID = @id 
                       and StartDateTime >= @start
                       and StartDateTime <= @end";
    using(SqlConnection cn = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand(cmdText, cn))
    {
        cn.Open();
        cmd.Parameters.Add("@id", cPOD.PODObjectID);
        cmd.Parameters.Add("@start", StartDate);
        cmd.Parameters.Add("@start", EndDate);
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
            ....
        }
    }
      
