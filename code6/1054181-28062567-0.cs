    var interfaces =  System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
    
    foreach (var netInterface in interfaces)
    {
         IPInterfaceProperties ipProps = netInterface.GetIPProperties();
    
         foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
         {
               Console.WriteLine(addr.Address.ToString());
         }                 
    } 
