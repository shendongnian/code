    public static string ConvertToFacebookLikeTime(DateTime value)
            {
                const int SECOND = 1;
                const int MINUTE = 60 * SECOND;
                const int HOUR = 60 * MINUTE;
                const int DAY = 24 * HOUR;
                const int MONTH = 30 * DAY;
    
                TimeSpan ts = DateTime.Now - value;
                double delta = ts.TotalSeconds;
    
                if (delta < 0)
                {
                    return "Right Now";
                }
                if (delta < 1 * MINUTE)
                {
                    //return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
                    return "A Few Seconds Ago";
                }
                if (delta < 2 * MINUTE)
                {
                    return "A Minute Ago";
                }
                if (delta < 45 * MINUTE)
                {
                    return ts.Minutes + "Minutes Ago";
                }
                if (delta < 90 * MINUTE)
                {
                    return "An Hour Ago";
                }
                if (delta < 24 * HOUR)
                {
                    return ts.Hours + " Hours Ago";
                }
                if (delta < 48 * HOUR)
                {
                    return "Yesterday";
                }
                if (delta < 30 * DAY)
                {
                    return ts.Days + " Days Ago";
                }
                if (delta < 12 * MONTH)
                {
                    int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                    return months <= 1 ? "A Month Ago" : months + "Months Ago";
                }
                else
                {
                    int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                    return years <= 1 ? "A Year Ago" : years + " Years Ago";
                }
            }
