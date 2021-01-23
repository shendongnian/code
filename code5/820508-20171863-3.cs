        command.Connection = conn;
        command.CommandType = CommandType.StoredProcedure; //Look up the actual code using intellisense as I dont recall what CommandType a stored Procedure is.
        command.paramaters.addwithvalue (@age, txtAge.text)  //using this as an example. Youw ill actually need to put in the same variables declared in SQL and where they correspond to on the screen.
     command.Connection.Open();
        adapter.InsertCommand = command;
        adapter.InsertCommand.ExecuteNonQuery();
        command.Connection.Close();
        Clear();
