    int newID = -1;
    string commandString = "insert (code, desc, numbervalue) values (@code,    @desc,@numbervalue); select cast(scope_identity() as int);"
    using(SqlCommand cmd = new SqlCommand(commandString))
    {
        try
        {
              cmd.Parameters.Add("@code", )
              // etc
              int newid=(int)(cmd.ExecuteScalar()??-1);
        }
        catch(Exception e)
        {
             // something went wrong
        }
    }
    if(newID!=-1)
    {
        // do something;
    }
