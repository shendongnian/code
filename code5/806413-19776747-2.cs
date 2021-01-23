            using (var con = new SqlConnection("XX"))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = "INSERT ABC VALUES(@AccountNumber, @Name, ";//...you need to fill in all the parameters
                command.Parameters.Add("@AccountNumber", SqlDbType.Text);//Pick proper SqlDbType...whatever it is I dunno
                command.Parameters["@AccountNumber"].Value = AccountNumber.Text;
                //rinse and repeat for rest of params
                con.Open();
                command.ExecuteNonQuery();                
            }//using will automatically correctly close and dipose of the connection when con goes out of scope.
