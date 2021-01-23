    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;   
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static string baseUrl = ConfigurationManager.AppSettings["AlexaServiceUrl"];
            private static string accessKeyId = ConfigurationManager.AppSettings["AlexaAccessKeyId"];
            private static string accessKey = ConfigurationManager.AppSettings["AlexaAccessKey"];
            private static string serviceVersion = ConfigurationManager.AppSettings["AlexaServiceVersion"];
            static void Main(string[] args)
            {
                HttpClient client = new HttpClient();
                string requestParameters = "AWSAccessKeyId=" + accessKeyId + "&Action=TopSites&Count=10&CountryCode=&ResponseGroup=Country&SignatureMethod=HmacSHA256&SignatureVersion=2&Start=1001&Timestamp=" + Amazon.Util.AWSSDKUtils.UrlEncode(Amazon.Util.AWSSDKUtils.FormattedCurrentTimestampISO8601, false);
                var signature = generateSignature(requestParameters);
                var url = "http://" + baseUrl + "/?" + requestParameters + "&Signature=" + signature;
                HttpResponseMessage message = client.GetAsync(url).Result;
                            
                Console.ReadKey();
            }
            private static string generateSignature(string queryParameters)
            {
                string stringToSign = String.Format("GET{0}{1}{2}/{3}{4}", "\n", baseUrl, "\n", "\n", queryParameters);
                var bytesToSign = Encoding.UTF8.GetBytes(stringToSign);
                var secretKeyBytes = Encoding.UTF8.GetBytes(accessKey);
                var hmacSha256 = new HMACSHA256(secretKeyBytes);
                var hashBytes = hmacSha256.ComputeHash(bytesToSign);
                var signature = Amazon.Util.AWSSDKUtils.UrlEncode(Convert.ToBase64String(hmacSha256.Hash), false);
                Trace.Write("String to sign:{0}", signature);
                return signature;
            }
        }
    }
