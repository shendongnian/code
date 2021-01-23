    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.Web.Script.Serialization; //Add a reference to System.Web.Extensions.dll to your project.
    class Program
    {
        static void Main()
        {
            string jsonString;
            using( WebClient client = new WebClient() )
            {
                jsonString = client.DownloadString( "http://rate-exchange.appspot.com/currency?from=USD&to=SEK&q=1" );
            }
            var serializer = new JavaScriptSerializer();
            var jsonObject = serializer.Dezerialize<Dictionary<string, object>>( jsonString );
            double rate = Double.Parse( jsonObject["rate"] );
            double v    = Double.Parse( jsonObject["v"] );
        }
    }
