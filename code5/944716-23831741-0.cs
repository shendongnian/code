    var MyOleDBCommand = MyOleDBConnection.CreateCommand();
    MyOleDBCommand.CommandText = "SELECT RECNO() FROM table_name WHERE foo=''";
 
    int row_id = -1;
    
    /** Search for some matching rows **/
    using(var reader = MyOleDBCommand.ExecuteReader()){
     // Check if something was found
     if(reader.HasRows){
       reader.Read(); // Read only the first row (or use a for-loop if you need more then 1)
       row_id = (int)reader.GetDecimal(0);
     }
    }
    /** If a matching row was found **/
    if(row_id > -1){
      MyOleDBCommand.CommandText = "UPDATE table_name SET foo='bar' WHERE RECNO()="+row_id;
      if(MyOleDBCommand.ExecuteNonQuery()>0){
        //Successfully Updatet
      }}
    }
