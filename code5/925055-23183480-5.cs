    public class Signs
    {
       static List<string> SignList = new List<string>() {  "Aquarius", "Pisces", "Aries", "Taurus", "Not Found"};
    
       static List<int> startDates = new List<int>() {
           // month * 100 + day of month
           121,
           220,
           321,
           421,
           1231
      };
            
        static public string Sign(DateTime inDate)
        {
           return SignList.Zip(startDates, (s, d) => new { sign = s, date = d })
                          .Where(x => (inDate.Month*100)+inDate.Day <= x.date)
                          .Select(x => x.sign)
                          .First();
        }
    }
 
