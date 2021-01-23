    async void Main()
    {	
    	TimeAndTemp tt = await GetTimeAndTemp();
    
    	tt.Time.Dump();
    	tt.Temperature.Dump();
    }
    
    async Task<TimeAndTemp> GetTimeAndTemp()
    {
    	return new TimeAndTemp();
    }
    
    public class TimeAndTemp
    {
    	public DateTime Time = DateTime.Now;
    	public int Temperature = 32;
    }
