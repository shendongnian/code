    private static readonly DateTime expiration = new DateTime(2013, 10, 31);
    static void Main()
    {
        DateTime currentTime = GetTimeFromSomeTimeServer();//Implement yourself
        if (currentTime.Date >= expiration.Date)
        {
            return;//Dont run the app
        }
        //Rest of your code...
    }
