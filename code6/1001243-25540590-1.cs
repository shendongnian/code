    else if (CompareUsername != ReceivedUsername || ComparePassword != ReceivedPassword)
    {
    if (!reader.Read())  //remove this condition it will skip the current loop                             
    {
    Log.Debug(ReceivedUsername + " has not logged in successfully with password: " + ReceivedPassword);
    myConnection.Close();//close sql conn
    reader.Close();//close sql data reader
    return ValidLogin;
    }
    }
