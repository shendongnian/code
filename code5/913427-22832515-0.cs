    private string GetTimeSpan(DateTime toDateTime, DateTime fromDateTime)
        {
            TimeSpan ts = toDateTime- fromDateTime;
            if (ts.Days < 0)
            {
                return "since " + ts.Days.ToString().Replace("-", string.Empty) + " Days";
            }
            else if (ts.Hours < 1)
            {
                return "in " + ts.Minutes + " Minutes";
            }
            else if (ts.Days < 1)
            {
                return "in " + ts.Hours + " Hours";
            }
            else if (ts.Days < 7)
            {
                return "in " + ts.Days + " Days";
            }
            else
            {
                return "in " + ts.Days / 7 + " Weeks";
            }
        }
