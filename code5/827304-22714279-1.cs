            MonsterBusinessGatewayService gateway = new MonsterBusinessGatewayService();
            gateway.Url = "https://208.71.198.74:8443/bgwBroker";
            gateway.Proxy = proxy;
            proxy.Credentials = cre;
            gateway.UseDefaultCredentials = true;
            gateway.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        
            gateway.Security = security;
            security.UsernameToken = user;
            user.Password = pass;
            gateway.Security.UsernameToken.Username = "xtestxftp";
            gateway.Security.UsernameToken.Password.Value = "ftp12345";
            Job job = new Job();
            JobsResponse jobresp = gateway.UpdateJob(job);
