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
        private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";
        static void Main(string[] args)
        {
            Console.WriteLine("BigQuery API - Service Account");
            Console.WriteLine("==========================");
            String serviceAccountEmail = "SERVICE_ACCOUNT_EMAIL_HERE";
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
            //Note: all your requests will run against Service.
        }
    }
