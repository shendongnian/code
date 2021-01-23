    string whatToDo = "null";
    bool exitApp = false;
    while (!exitApp)
    {
    	whatToDo = AdvTime.MainMenu();
    	if (whatToDo.Contains("play"))
    	{
    		Menu("null", false);
    	}
    	if (whatToDo.Contains("options"))
    	{
    		AdvTime.OptionMenu();
    	}
    	if (whatToDo.Contains("exit"))
    	{
    		exitApp = true;
    	}
    	if (whatToDo.Contains("null"))
    	{
    		AdvTime.MMError("OM");
    	}
    }
