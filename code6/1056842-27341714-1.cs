    var searcher = new ManagementObjectSearcher(
        "select CommandLine,ProcessId from Win32_Process where Name='svchost.exe'" );
    var retObjectCollection = searcher.Get( );
    foreach(var proc in retObjectCollection)
    {
        var procSearch = new ManagementObjectSearcher( 
            String.Format(
                "select * from Win32_Service where ProcessId='{0}'",
                proc["ProcessId"]));
         foreach(var svc in  procSearch.Get( ))
         {
            if( ((string)svc["PathName"]).Contains( "-k NetworkService" ))
            {
                // do nasty things with the info
                svc.Dump();
            }
         }
    }
