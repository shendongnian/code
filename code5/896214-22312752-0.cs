    foreach (var i in NetworkInterface.GetAllNetworkInterfaces())
    {
       Console.WriteLine("{0} ({1})", i.Name, i.NetworkInterfaceType);
       foreach (var a in i.GetIPProperties().UnicastAddresses)
       {
          Console.WriteLine("      {0} ({1})", a.Address, a.Address.AddressFamily);
       }
    }
