            using System.ServiceProcess;
            .
            .
            .            
            ConnectionOptions options = new ConnectionOptions();
            options.Password = "password here";
            options.Username = "username";
            options.Impersonation =
                System.Management.ImpersonationLevel.Impersonate;
            
            // Make a connection to a remote computer. 
            // Replace the "FullComputerName" section of the
            // string "\\\\FullComputerName\\root\\cimv2" with
            // the full computer name or IP address of the 
            // remote computer.
            ManagementScope scope =
                new ManagementScope(
                "\\\\FullComputerName\\root\\cimv2", options);
            scope.Connect();
    
    
            ServiceController sc = new ServiceController("ServiceName", "fullComputerName");
            sc.Start();``
