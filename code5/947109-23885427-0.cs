    using System;
    using Google.Apis.Auth.OAuth2;
    using System.Security.Cryptography.X509Certificates;
    using Google.Apis.Bigquery.v2;
    using Google.Apis.Services;
    
    //Install-Package Google.Apis.Bigquery.v2
    namespace GoogleBigQueryServiceAccount
    {
        class Program
        {
            
            static void Main(string[] args)
            {
    
                Console.WriteLine("BigQuery API - Service Account");
                Console.WriteLine("==========================");
    
                String serviceAccountEmail = "539621478854-imkdv94bgujcom228h3ea33kmkoefhil@developer.gserviceaccount.com";
    
                var certificate = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);
    
                ServiceAccountCredential credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(serviceAccountEmail)
                   {
                       Scopes = new[] { BigqueryService.Scope.DevstorageReadOnly }
                   }.FromCertificate(certificate));
    
                // Create the service.
                var service = new BigqueryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "BigQuery API Sample",
                });
    
    
            }
        }
    }
