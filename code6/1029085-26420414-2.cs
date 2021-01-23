    connection.ConnectionTimeout = 1; //timeout in seconds
    //initialize command, connection etc
    bool commited;
    while(!commited){
       try{
          MySqlDataReader dataReader = command.ExecuteReader(); 
          commited = true;
       }catch(Exception e) {
          commited = false;
       }
       //code to force program update.
    }
