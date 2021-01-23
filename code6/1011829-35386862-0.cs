      public static void StartListener() {
        using (var hl = new HttpListener()) {
          hl.Prefixes.Add("http://+:8008/");
          hl.AuthenticationSchemes = AuthenticationSchemes.Basic;
          hl.Start();
          Console.WriteLine("Listening...");
          while (true) {
            var hlc = hl.GetContext();
    
            var hlbi = (HttpListenerBasicIdentity)hlc.User.Identity;
            Console.WriteLine(hlbi.Name);
            Console.WriteLine(hlbi.Password);
    
            //TODO: validater user
            //TODO: take action
          }
        }
      }
