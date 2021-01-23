    using System;
    using System.Text;
    using Microsoft.Web.Administration;
    private void CheckAuthenticationModes()
    {
      using(ServerManager serverManager = new ServerManager()) { 
         Configuration config = serverManager.GetApplicationHostConfiguration();
         //replace myWebApp with your webapplication name.   
         ConfigurationSection anonymousAuthenticationSection = config.GetSection("system.webServer/security/authentication/anonymousAuthentication", "myWebApp");
         var anonymousAuthentication= anonymousAuthenticationSection["enabled"];
         ConfigurationSection windowsAuthenticationSection = config.GetSection("system.webServer/security/authentication/windowsAuthentication", "myWebApp");
         var windowsAuthentication= windowsAuthenticationSection["enabled"];
        
      }
    }
