    static void Main()
    {
        var host = new JobHost();
        host.CallAsync(typeof(Functions).GetMethod("ProcessMethod"));
        // The following code ensures that the WebJob will be running continuously
        host.RunAndBlock();
    }
    
    [NoAutomaticTriggerAttribute]
    public static async Task ProcessMethod(TextWriter log)
    {
        while (true)
        {
            try
            {
                log.WriteLine("There are {0} pending requests", pendings.Count);
            }
            catch (Exception ex)
            {
                log.WriteLine("Error occurred in processing pending altapay requests. Error : {0}", ex.Message);
            }
    		await Task.Delay(TimeSpan.FromMinutes(3));
        }
    }
