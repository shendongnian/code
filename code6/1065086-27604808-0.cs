    if(reader.HasRows)
      {
       while(reader.Read()) // == this is the Read() method was called
           {
            val.IDDataUser = reader.GetString(0); === error at this line
            val.Username = reader.GetString(1);
            val.Password = reader.GetString(2);
            Console.WriteLine("data_user di conDb: " + val.IDDataUser);
           }
       }
