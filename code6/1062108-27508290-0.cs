     private static void IPAddresses(string server) 
        {
          try 
          {
            System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
    
            // Get server related information.
            IPHostEntry heserver = Dns.GetHostEntry(server);
    
            // Loop on the AddressList 
            foreach (IPAddress curAdd in heserver.AddressList) 
            {
    
    
              // Display the type of address family supported by the server. If the 
              // server is IPv6-enabled this value is: InternNetworkV6. If the server 
              // is also IPv4-enabled there will be an additional value of InterNetwork.
              Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());
    
              // Display the ScopeId property in case of IPV6 addresses. 
              if(curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());
    
    
              // Display the server IP address in the standard format. In  
              // IPv4 the format will be dotted-quad notation, in IPv6 it will be 
              // in in colon-hexadecimal notation.
              Console.WriteLine("Address: " + curAdd.ToString());
    
              // Display the server IP address in byte format.
              Console.Write("AddressBytes: ");
    
    
    
              Byte[] bytes = curAdd.GetAddressBytes();
              for (int i = 0; i < bytes.Length; i++) 
              {
                Console.Write(bytes[i]);
              }                          
    
              Console.WriteLine("\r\n");
    
            }
      }
