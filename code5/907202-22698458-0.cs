    using System;  
    using System.IO;  
    using System.Net;  
    using System.Text;  
    using System.Xml;  
    using NUnit.Framework;  
    namespace Examples.System.Net  
    {  
        public class WebRequestPostExample  
        {  
            public static void Main()  
            {  
    String b = "OK";  
                // Create a request using a URL that can receive a post. 
  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("your end point here");  
            
            request.Headers.Add ("SOAPAction", "some soap action here");  
            request.ContentType = "text/xml;charset=\"utf-8\"";  
            request.Accept = "text/xml";  
            request.Method = "POST";
            
            // Set the Method property of the request to POST.  
            request.Method = "POST";  
            // Create POST data and convert it to a byte array.  
            string postData = @"<s:Envelope xmlns:s="Som request that you want to send";  
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);  
            request.ContentLength = byteArray.Length;  
            Stream stream = request.GetRequestStream();  
            
            stream.Write(byteArray, 0, byteArray.Length);  
            int a = 0;  
            stream.Close();  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();  
            Assert.AreEqual(response.StatusCode, b, "Pass");  
            
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);  
