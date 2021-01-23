     private void Update()
        {
           using(SqlConnection conn = new SqlConnection(yourConnString) )
           {
             string qry = "Update YourTable Set Field1=@Val1,Field2=@Val2,Field3=@Val3 Where YourPrimaryKey=@Key";
             using(SqlCommand command = new SqlCommand(qry,conn))
             {
               conn.Open();
               command.CommandType= CommandType.Text;
               command.Parameters.Add("@Val1",txt1.Text);
               command.Parameters.Add("@Val2",txt2.Text);
               command.Parameters.Add("@Val3",txt3.Text);
               command.Parameters.Add("@Key",txt4.Text);
               int i = command.ExecuteNonQuery();
               con.Close();
             }
            
        
           }
        }
