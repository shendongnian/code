    public class UnixTime
    {
       public readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
    
       public int unixFormat3(string dateTimeInput, string inputFormat, int hours)
       {
          DateTime result = DateTime.ParseExact(dateTimeInput, inputFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        
            int unixTime = (int)(result.AddHours(hours).Subtract(UnixTime.Epoch)).TotalSeconds;
            return unixTime;
        }
    }
