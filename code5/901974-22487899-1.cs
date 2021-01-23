    if(File.Exists("achievements.txt"))
    {
    	string[] achCheckStr = File.ReadAllLines("achievements.txt");
    	if(achCheckStr.Length > 0)
    	{
    		if (achCheckStr[0] == ach1_StillBurning) 
    		{
    			setAchievements(1);
    		}
    		if (achCheckStr[1] == ach2_Faster)
    		{
    			setAchievements(2);
    		}
    	}
    }
