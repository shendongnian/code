    DateTime currentDate = DateTime.Now;
        //currentDate = DateTime.Parse("9/8/2014");       //Just for test.
        List<PastWeekDays> list = new List<PastWeekDays>();
        //Started loop from 2 beacause it will pick current datetime every monday,so 2 days ago will be saturday.
        for (int i =2; i < 9; i++)
        {
            DateTime lastDate = currentDate.AddDays(-double.Parse((i).ToString()));
            if (lastDate.Month != currentDate.Month)
                break;
            PastWeekDays day = new PastWeekDays();
            day.Date = lastDate.Day.ToString();
            day.DayName = lastDate.DayOfWeek.ToString();
            list.Add(day);
        }
    //This is custom class you may not need it.
    public class PastWeekDays
    {
    public string Date { get; set; }
    public string DayName { get; set; }
    }
