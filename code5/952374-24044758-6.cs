    public class Degree
    {
        int degrees;
        int minutes;
        int seconds;
    
        public static Degree Parse(string input)
        {
          //Implementation below
        }
    
        public decimal ToDecimal()
        {
           // From https://stackoverflow.com/a/3249890/1783619
           // Modified to use floating point division since my inputs are ints.
           //Decimal degrees = 
           //   whole number of degrees, 
           //   plus minutes divided by 60, 
           //   plus seconds divided by 3600
           return degrees + (minutes/60f) + (seconds/3600f);
        }
    }
