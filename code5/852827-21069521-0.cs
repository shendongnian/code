    private void Insert()
    {
       using(SqlConnection conn = new SqlConnection(yourConnString) )
       {
         string qry = "Insert into YourTable Select (@Val1,@Val2,@Val3)";
         using(SqlCommand command = new SqlCommand(qry,conn))
         {
           conn.Open();
           command.CommandType= CommandType.Text;
           command.Parameters.Add("@Val1",txt1.Text);
           command.Parameters.Add("@Val2",txt2.Text);
           command.Parameters.Add("@Val3",txt3.Text);
           int i = command.ExecuteNonQuery();
           con.Close();
         }
        
    
       }
    }
