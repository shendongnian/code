    public int GetData(int Time_s, out int Count, ref double[] Results)
    {
        var lengthIncrement = 100;
        Count = 0;
        
        try
        {
            DateTime timeout = DateTime.UtcNow.AddSeconds(Time_s);
            double[] values;    
            while (DateTime.UtcNow < timeout)
            {
                values = //here is the command to tell the instrument to return 10 results
                //Before copying over value, make sure we won't overflow
                //If we will, extend array
                if (Count + values.Length > Results.Length) {
                   var temp = new double[Results.Length + lengthIncrement];
                   Array.Copy(Results, temp, Count);
                   Results = temp;
                }                
                Array.Copy(values, 0, Results, Count, values.Length);
                Count += values.Length;
                Thread.Sleep(500);
            }    
        }
        return 0;
    }
