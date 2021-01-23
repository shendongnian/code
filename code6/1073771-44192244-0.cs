    try
    {
      cmd.CommandType = CommandType.Text;
      dr = cmd.ExecuteReader(); 
    }
    catch (OracleException ex)
    {
      Console.WriteLine("Record is not inserted into the database table.");
      Console.WriteLine("Exception Message: " + ex.Message);
      Console.WriteLine("Exception Source: " + ex.Source);
    }
