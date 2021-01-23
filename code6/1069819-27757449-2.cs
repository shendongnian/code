    void Main()
    {
    	int max = 100000;
    	long[] feSampling = new long[max];
    	long[] exSampling = new long[max];
    	
    	String pathRoot ="C:\\MISSINGFILE.TXT";
    	String path = null;
    	
    	Stopwatch sw = new Stopwatch();
    	for (int i = 0; i < max; i++)
    	{
    		path = pathRoot + i.ToString();
    		sw.Start();
    		File.Exists(pathRoot);
    		sw.Stop();
    		feSampling[i] = sw.ElapsedTicks;
    		
    		sw.Reset();
    	}
    	
    	StreamReader sr = null;
    	sw.Reset();
    	for (int i = 0; i < max; i++)
    	{
    		path = pathRoot + i.ToString();
    		try
    		{	        
    			sw.Start();
    			sr = File.OpenText(path);
    		}
    		catch (FileNotFoundException)
    		{
    			sw.Stop();
    			exSampling[i] = sw.ElapsedTicks;
    			sw.Reset();
    			
    			if(sr != null) { sr.Dispose();}
    		}
    	}
    	
    	Console.WriteLine("Total Samplings Per Case: {0}", max);
    	Console.WriteLine("File.Exists (Ticsk) - Min: {0}, Max: {1}, Mean: {2}", feSampling.Min(), feSampling.Max(), feSampling.Average ());
    	Console.WriteLine("FileNotFoundException (Ticks) - Min: {0}, Max: {1}, Mean: {2}", exSampling.Min(), exSampling.Max(), exSampling.Average ());
    	
    }
