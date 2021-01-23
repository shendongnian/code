    void Main()
    {	
    	Task<TimeAndTemp> timeAndTempTask = GetTimeAndTemp();
    	timeAndTempTask.ContinueWith (_ => 
    		{
    			timeAndTempTask.Result.Time.Dump();
    			timeAndTempTask.Result.Temperature.Dump();
    		});	
    }
    
    Task<TimeAndTemp> GetTimeAndTemp()
    {
    	var tcs = new TaskCompletionSource<TimeAndTemp>();
    	
    	new Timer (_ => tcs.SetResult (new TimeAndTemp())).Change (3000, -1);
    	
    	return tcs.Task;
    }
    
    public class TimeAndTemp
    {
    	public DateTime Time = DateTime.Now;
    	public int Temperature = 32;
    }
