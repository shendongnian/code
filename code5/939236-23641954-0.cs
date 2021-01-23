     public static void RegisterNewUser(string username, string password, string email)
    {
    	try
    	{
    		string udir = root + username;
    		Directory.CreateDirectory(udir);
    		Directory.CreateDirectory(udir + "/weapons");
    		Directory.CreateDirectory(udir + "/loadouts");
    		File.WriteAllText(udir + "/password.sav", password);
    		File.WriteAllText(udir + "/level.sav", "1");
    		File.WriteAllText(udir + "/money.sav", "1000");
    		File.WriteAllText(udir + "/email.sav", email);
    		File.WriteAllText(udir + "/loadout.gfl", "");
    		using (StreamWriter sw = new StreamWriter(root + "emails.txt", true))
    		{
    			sw.WriteLine(email);
    		}
    		Email.Send(email, "New Account Registration", string.Format(mailTemplate, username, password));
    	}
    	catch (Exception ex)
    	{
    		// Create a method to display or log the exception, with it's own error handler
    		LogAndDisplayExceptions(ex);
    		// Send the user a message that we failed to add them. Put this in it's own try-catch block
    		// ideally, for readability, in it's own method.
    		try
    		{
    			Email.Send(email, "Failed to register", "An error occurred while trying to add your account.");
    		}
    		catch (Exception exNested)
    		{
    			LogAndDisplayExceptions(exNested);
    		}
    	}
    }
