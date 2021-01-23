    public int FetchDatalog(int Time_s, double Period, out int Count, ref double[] Results)
    {
        Count = 0;
        List<double> existing = new List<double>(Results);
    
        try
        {
            DateTime timeout = DateTime.UtcNow.AddSeconds(Time_s);
            double[] values;    
            while (DateTime.UtcNow < timeout)
            {
                values = //here is the command to tell the instrument to return 10 results
                Count += values.Length;
                Thread.Sleep(500);
                
                existing.AddRange(values);
            }    
        }
        finally 
        {
            Results = existing.ToArray();        
        }
        return 0;
    }
