    SqlCommand cmd = new SqlCommand("SELECT blueBallImage FROM CorrespondingBall WHERE objective = @blue", con); 
    cmd.CommandType = CommandType.Text; 
    cmd.Parameters.AddWithValue("@blue", CheckForDbNull(image));
    ...
    public static object CheckForDbNull(object value)
    {
       if(value == null)
       {
           return DBNull.Value;
       }
    
       return value;
    }
