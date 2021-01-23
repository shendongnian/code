    using(var searcher = new ManagementObjectSearcher(
              "select CommandLine,ProcessId from Win32_Process where Name='svchost.exe'" ))
    {
        using(var  retObjectCollection = searcher.Get( ))
        {
            foreach(var proc in retObjectCollection)
            {
                using(var procSearch = new ManagementObjectSearcher( 
                    String.Format(
                        "select * from Win32_Service where ProcessId='{0}'",
                        proc["ProcessId"])))
                {
                    using(var procResult = procSearch.Get( ))
                    {
                        foreach(var svc in  procResult)
                        {
                            if( ((string)svc["PathName"]).Contains( "-k NetworkService" ))
                            {
                                // do nasty things with the info
                                svc.Dump();
                            }
                        }
                    }
                }
            }
        }
    }
