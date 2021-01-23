    using (var command = new SqlCommand("Submit_Data", connect) { CommandType = CommandType.StoredProcedure }) 
    {
       connect.Open();
    
       command.Parameters.Add(new SqlParameter("@Firstname", datFirstname));
       command.Parameters.Add(new SqlParameter("@Surname", datSurname));
       command.Parameters.Add(new SqlParameter("@Visiting", datVisiting));
       command.Parameters.Add(new SqlParameter("@Car_Reg", datReg));
    
       command.ExecuteNonQuery();
       connect.Close();
    }
