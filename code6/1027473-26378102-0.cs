    // try to write maximum of 3 times
    var maxRetry = 3;
    for (int retry = 0; retry < maxRetry; retry++)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(logfile, true))
            {
                sw.WriteLine("{0} KYEC{1} {2}", tick, Environment.MachineName, msg);
                break; // you were successfull so leave the retry loop
            }
        }
        catch (IOException)
        {
            if(retry < maxRetry)
            {
                System.Threading.Thread.Sleep(2000); // Wait some time before retry (2 secs)
            }
            else
            {
                // handle unsuccessfull write attempts or just ignore.
            }
        }
    }
