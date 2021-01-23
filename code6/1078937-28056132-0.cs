    foreach (Player player in players)
	{
		try
		{
		    string pointsString="ExampleString"+Player.Name;
	        pointsString = document.DocumentNode
	        .SelectSingleNode(pointsString)
	        .InnerText;
		}
		catch (Exception ex)
		{
			// Use player here, break out of the 
			// foreach loop if necessary.
            return View("Error at player " + player.Name);
		}
	}
