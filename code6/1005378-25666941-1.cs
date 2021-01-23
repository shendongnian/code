    using (
        SqlConnection conn =
            new SqlConnection(
                ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
    {
        conn.Open();
        string updateQuery =
            @"UPDATE Details 
            SET Employees = @employeee, 
            Performance = @performance , 
            TotalPerformance = @totalPerformance,
            Attitude = @attitude,
            TotalAttitude = @totalattitude
            WHERE yourField = @yourConditionValue";
        using (SqlCommand com = new SqlCommand(updateQuery, conn))
        {
            com.Parameters.AddWithValue("@employees", Request.QueryString["employees"]);
            com.Parameters.AddWithValue("@performance", totalPer.ToString());
            com.Parameters.AddWithValue("@totalPerformance", totalPercent.ToString());
            com.Parameters.AddWithValue("@attitude", totalAtt.ToString());
            com.Parameters.AddWithValue("@totalattitude", totalPercent.ToString());
            com.Parameters.AddWithValue("@yourConditionValue", yourValue);
            com.ExecuteNonQuery();
        }
    }
