    for (int i = 0; i < 5; i++)
    {
        DateTime date = sd.AddSeconds(inteval * i);
        
        if (locked)
        {
                    DateTime psdate = sd.AddSeconds(-sPeriod);
                }
                else
                {
                    DateTime psdate = sd.AddSeconds((inteval * i) - sPeriod));
                }
                DateTime pedate = sd.AddSeconds((inteval * i) - ePeriod);
       }
       //...
