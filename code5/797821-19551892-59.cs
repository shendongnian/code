	void Main()
	{
	    var subscription = Poll(SomeRestCall,
	                            ParameterFactory,
	                            TimeSpan.FromSeconds(5),
	                            ThreadPoolScheduler.Instance)
	        .TimeInterval()                            
	        .Subscribe(x => {
	            Console.Write("Interval: " + x.Interval);
	            var result = x.Value;
	            if(result.IsRight)
	                Console.WriteLine(" Success: " + result.Right);
	            else
	                Console.WriteLine(" Error: " + result.Left.Message);
	        });
	        
	    Console.ReadLine();    
	    subscription.Dispose();
	}
	Interval: 00:00:01.0027668 Success: 1-ret
	Interval: 00:00:05.0012461 Error: Exception of type 'System.Exception' was thrown.
	Interval: 00:00:06.0009684 Success: 3-ret
	Interval: 00:00:05.0003127 Error: Exception of type 'System.Exception' was thrown.
	Interval: 00:00:06.0113053 Success: 5-ret
	Interval: 00:00:05.0013136 Error: Exception of type 'System.Exception' was thrown.
