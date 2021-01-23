    String input = @"login_cmd=&login_params=&login_email=my%40mail.de&login_password=TOPsecret&submit..........";
     
    Regex rgx = new Regex(@"(?<=login_email=)([^&]+)|(?<=login_password=)([^&]+)");
     
    foreach (Match m in rgx.Matches(input))
    {
    	if(!m.Groups[1].Value.ToString().Equals(string.Empty))
    	{
    		Console.WriteLine("Email : " + m.Groups[1].Value);
    	}
    		if(!m.Groups[2].Value.ToString().Equals(string.Empty))
    	{
    		Console.WriteLine("Password : " + m.Groups[2].Value);
    	}
    }
