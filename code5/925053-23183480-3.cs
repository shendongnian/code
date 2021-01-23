    public class Signs
    {
       static List<string> SignList = new List<string>() {  "Aquarius", "Pisces", "Aries", "Taurus", "Not Found"};
    
       static DateTime[] startDates =  {
            new DateTime(DateTime.Now.Year,1,21),
            new DateTime(DateTime.Now.Year,2,20),
            new DateTime(DateTime.Now.Year,3,21),
            new DateTime(DateTime.Now.Year,4,21)
            new DateTime(DateTime.Now.Year,12,31)  };
    
        static public string Sign(DateTime inDate)
        {
           return SignList.Zip(startDates, (s, d) => new { sign = s, date = d })
                          .Where(x => (inDate.Month*100)+inDate.Day <= (x.date.Month*100)+x.date.Day)
                          .Select(x => x.sign)
                          .First();
        }
    }
