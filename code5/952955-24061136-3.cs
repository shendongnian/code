      using System.Security;
      using System.Security.Cryptography; 
      ...
    
      public static String GetHashValue(String password) {
        // You may find useful to add "salt" here:
        // Byte[] buffer = Encoding.ASCII.GetBytes(password + "some const irregular string");
        Byte[] buffer = Encoding.ASCII.GetBytes(password);
    
        // I've chosen the strongest (but the longest) hash provider
        using (SHA256 provider = SHA256Managed.Create()) {
          return String.Join("", provider.ComputeHash(buffer).Select(x => x.ToString("X2")));
        }
      }
