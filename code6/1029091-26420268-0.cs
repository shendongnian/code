    using (SqlConnection con7 = new SqlConnection(cs))
    {
       using (SqlCommand cmd71 = con7.CreateCommand())
       {
           cmd71.CommandText = "update details set  result = @result where student_id ='11'";
           cmd71.Parameters.Add("@result", SqlDbType.NVarChar).Value = initial_result + finalresult;
           cmd71.ExecuteNonQuery();
       }
    }
