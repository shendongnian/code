     bool flag = false;
     using(SqlConnection connection = new SqlConnection("Data Source=HOMESERV;Initial Catalog=JSO;Integrated Security=True;MultipleActiveResultSets=True"))
     using(SqlCommand command = new SqlCommand("select * from EMPLOYEE where [EMP ID]=@id", connection);
     {
          connection.Open();
          command.Parameters.AddWithValue("@id", EMP_ID);
          flag = Convert.ToBoolean(command.ExecuteScalar());
     }
     return flag;
