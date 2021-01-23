    public class Signs2
    {
      static List<string> SignList = new List<string>() {  "Aquarius", "Pisces", "Aries", "Taurus", "Not Found"};
    
      static List<int> startDates = new List<int>() {
        // month * 100 + day of month
         121,
         220,
         321,
         421,
        9999 // edge marker
      };
            
      static public string Sign(DateTime inDate)
      {
        return SignList[startDates.TakeWhile(d => (inDate.Month*100)+inDate.Day > d).Count()];
      }
    }
