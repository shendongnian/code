    using System;
    using System.Collections.Generic;
    using System.Web;
    
    using System.Configuration;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Data;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Urlshortener.v1;
    using Google.Apis.Urlshortener.v1.Data;
    using Google.Apis.Services;
    
    public static string shortenURL(string urlToShorten, string webSiteBasePath)
            {
                string shortURL = string.Empty;
            try
            {
                /********************************************************************/
                string AuthenticationToken = string.Empty;
                var certificate = new X509Certificate2(webSiteBasePath + "/" + ConfigurationManager.AppSettings["IHSGoogleURlShortenerPrivateKeyName"].ToString(),
                                                       ConfigurationManager.AppSettings["IHSGoogleURlShortenerPrivateKeySecret"].ToString(),
                                                       X509KeyStorageFlags.MachineKeySet |
                                                       X509KeyStorageFlags.PersistKeySet |
                                                       X509KeyStorageFlags.Exportable);
                String serviceAccountEmail = ConfigurationManager.AppSettings["IHSGoogleURLShortenerServiceAcEmail"].ToString();
                ServiceAccountCredential credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(serviceAccountEmail)
                   {
                       Scopes = new[] { UrlshortenerService.Scope.Urlshortener }
                   }.FromCertificate(certificate));
                if (credential.RequestAccessTokenAsync(CancellationToken.None).Result)
                {
                    AuthenticationToken = credential.Token.AccessToken;
                }
                // Create the service.
                var service = new UrlshortenerService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ConfigurationManager.AppSettings["IHSGoogleURLShortnerAppName"].ToString(),
                });
                // Shorten URL
                Url toInsert = new Url { LongUrl = urlToShorten };
                toInsert = service.Url.Insert(toInsert).Execute();
                shortURL = toInsert.Id;
            }
            
            return (shortURL);
        }
