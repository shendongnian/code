    public static bool NightTime
    {
        get
        {
            var hour = System.DateTime.Now.Hour;
            return (hour <=7 || hour >= 20);
        }
    }
