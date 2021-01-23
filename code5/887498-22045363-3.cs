    string sql = @"INSERT INTO Part1Table (CustomerDetails, TechnologyPartner, ResponseDate, 
                   FormID) VALUES (@CustomerDetails, @TechnologyPartner, @ResponseDate, @FormID)";
    using(SqlConnection myConnection = new SqlConnection(sConnection))
    SqlCommand cmdIns = new SqlCommand(sql, myConnection);
    {
       try
       {
           myConnection.Open();
           cmdIns.Parameters.Add("@CustomerDetails", SqlDbType.Char);
           cmdIns.Parameters["@CustomerDetails"].Value = box1value;
           //box2value
           cmdIns.Parameters.Add("@TechnologyPartner", SqlDbType.Char);
           cmdIns.Parameters["@TechnologyPartner"].Value = box2value;
           //box3value
           cmdIns.Parameters.Add("@ResponseDate", SqlDbType.DateTime);
           cmdIns.Parameters["@ResponseDate"].Value = box3value;
   
           cmdIns.Parameters.Add("@FormID", SqlDbType.Int);
           cmdIns.Parameters["@FormID"].Value = 1;
           // No parameter for the ROWID column. 
           // It will be an error to try to insert 
           // a value for that column
           cmdIns.ExecuteNonQuery();
           // Read back the value using the SAME connection used for the insert
           cmdIns.Parameters.Clear();
           cmdIns.CommandText = "SELECT SCOPE_IDENTITY()";
           object result = cmdIns.ExecuteScalar();
           int newRowID = Convert.ToInt32(result);
 
        }
    }
