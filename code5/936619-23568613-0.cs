    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Web;
    using System.Xml;
    namespace ExpiredSubscriptionStatus
    {
    internal class PutWSCall
    {
        public string externalBillingSubscriptionNumber;
        private static string _externalBillingSubscriptionURI = ConfigurationManager.AppSettings["externalBillingSubscriptionURI"];
        public void Put()
        {
            try
            {
                _externalBillingSubscriptionURI += externalBillingSubscriptionNumber + "/cancel";
                Uri address = new Uri(_externalBillingSubscriptionURI);
                // Create the web request  
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                // Set Headers and Content
                request.Method = "PUT";
                request.Headers.Add("apiAccessKeyId", "login");
                request.Headers.Add("apiSecretAccessKey", "password");
                request.ContentType = "application/json";
                //Build the Request Body
                var myDateTime = DateTime.Now;
                ZuoraCancelRequest zuoraRequestClass = new ZuoraCancelRequest();
                zuoraRequestClass.cancellationPolicy = "SpecificDate";
                zuoraRequestClass.cancellationEffectiveDate =  myDateTime.Date.ToString("yyyy-MM-dd");
                zuoraRequestClass.invoiceCollect = false;
                //Serialize the Object and add it to the WS request stream
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ReqSer = new DataContractJsonSerializer(typeof(ZuoraCancelRequest));
                ReqSer.WriteObject(stream, zuoraRequestClass);  //Serialize
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytes = encoding.GetBytes(sr.ReadToEnd());
                request.ContentLength = bytes.Length;
                //Send the WS request stream
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream(); //get the stream containing response data sent by the server
                //Deserialize the Json Response
                using (StreamReader reader = new StreamReader(dataStream, Encoding.UTF8))
                {
                    ZuoraCancelResponse zuoraResponseClass = new ZuoraCancelResponse();
                    MemoryStream memoryStream = new MemoryStream();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ZuoraCancelResponse));
                    ser.WriteObject(memoryStream, zuoraResponseClass);
                    memoryStream.Position = 0;
                    ZuoraCancelResponse zuoraCancelResponse = (ZuoraCancelResponse)ser.ReadObject(dataStream);
                }
            }
            catch (Exception ex)
            {
                throw ex;  //throw error back up to calling method
            }
        }
       
    }
}
