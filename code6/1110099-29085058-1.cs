    var emails = new List<EmailCode>();
    
    while (reader.Read())
    {
    	emails.Add(new EmailCode {Email = Convert.ToString(reader["email"]),
    		FirstName = Convert.ToString(reader["FirstName"]),
    		Program =  Convert.ToString(reader["Program"])
    		});
    }
    
    foreach (EmailCode email in emails)
    {
      //email codes
    }
