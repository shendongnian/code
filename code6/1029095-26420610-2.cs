    //reading values from db column and assigning to string
    string initial_result ="xxxxxx";
    //lengthier one
    string final_result="yyyyyyyyyy";
    string connectionstring = "your connection string here";
    string query = "update details set  result=@result where student_id = 11";
    using(SqlConnection con = new SqlConnection(connectionstring))
    {
       SqlCommand cmd = new SqlCommand(query,con);
       con.Open();
       cmd.Parameters.Add(new SqlParameter("@result", initial_result + finalresult));
       int executeresult = cmd.ExecuteNonQuery();
       if(executeresult > 0)
       {
          Response.Write("Update Success");
       }
       else
       {
          Response.Write("Unable to Update");
       }
       cmd.Dispose();
    }
