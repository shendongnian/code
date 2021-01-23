    public class Signs
    {
      static List<string> SignList = new List<string>() {
        "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Not Found" };
    
      static List<int> StartDates = new List<int>() {
        // month * 100 + day of month
         120, 219, 320, 420, 521, 621, 722, 821, 923, 1023, 1122, 1222, 1232, 9999 // edge marker
      };
            
      static public string Sign(DateTime inDate)
      {
        return SignList[StartDates.TakeWhile(d => (inDate.Month*100)+inDate.Day > d).Count()];
      }
    }
