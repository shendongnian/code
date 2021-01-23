    public int FetchDatalog(int readLength, double sleepPeriod, List<double> results)
    {
        var readingsCount = 0;
        try
        {
            var timeout = DateTime.UtcNow.AddSeconds(readLength);
            while (DateTime.UtcNow < timeout)
            {
                values = RetrieveBufferedSensorReadings(10);
                readingsCount += values.Length;
                results.AddRange(values);                
                Thread.Sleep(sleepPeriod);
            }
            return readingsCount;
        }
        catch (Exception e) //<-- this should be special purpose based on sleep/read failures
        {
           throw; //Return -1 or the like if you must... but ew.
        }
    }
