            // Add a new middleware issuing access tokens.
            app.UseOpenIdConnectServer(options =>
            {
                options.Provider = new AuthenticationProvider();
                // Enable the authorization, logout, token and userinfo endpoints.
                //options.AuthorizationEndpointPath = "/connect/authorize";
                //options.LogoutEndpointPath = "/connect/logout";
                options.TokenEndpointPath = "/connect/token";
                //options.UserinfoEndpointPath = "/connect/userinfo";
                // Note: if you don't explicitly register a signing key, one is automatically generated and
                // persisted on the disk. If the key cannot be persisted, an exception is thrown.
                // 
                // On production, using a X.509 certificate stored in the machine store is recommended.
                // You can generate a self-signed certificate using Pluralsight's self-cert utility:
                // https://s3.amazonaws.com/pluralsight-free/keith-brown/samples/SelfCert.zip
                // 
                // options.SigningCredentials.AddCertificate("7D2A741FE34CC2C7369237A5F2078988E17A6A75");
                // 
                // Alternatively, you can also store the certificate as an embedded .pfx resource
                // directly in this assembly or in a file published alongside this project:
                // 
                // options.SigningCredentials.AddCertificate(
                //     assembly: typeof(Startup).GetTypeInfo().Assembly,
                //     resource: "Nancy.Server.Certificate.pfx",
                //     password: "Owin.Security.OpenIdConnect.Server");
                // Note: see AuthorizationController.cs for more
                // information concerning ApplicationCanDisplayErrors.
                options.ApplicationCanDisplayErrors = true // in dev only ...;
                options.AllowInsecureHttp = true // in dev only...;
            });
