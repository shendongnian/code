    using (var conn = new SqlConnection("data source=MySource; initial catalog=MYNewDB;persist security info=True;user id=MyUser;password=MyPassword;multipleactiveresultsets=True; "))
    {
       string script = File.ReadAllText(@"C:\Somewhere\...\script.sql");
       // split script on GO command
       IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
       conn.Open();
       foreach (string commandString in commandStrings)
       {
          if (commandString.Trim() != "")
          {
             using (var command = new SqlCommand(commandString, conn))
             {
                command.ExecuteNonQuery();
             }
          }
       }
       conn.Close();
    }
