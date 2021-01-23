    private void beginOperstionChecker(DateTime dt)
    {
            string time = Options_DB.Get_OperationLastTime();
            DateTime lastTime  = DateTime.Parse(time);
            if (DateTime.Now - lastTime > new TimeSpan(0, 20, 0))
            {
                //It's passed more than 20mins from last save.
            }
    }
