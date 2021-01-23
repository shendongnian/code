     private void SendSMSAlert(String message)
        {
            try
            {
                String url = "https://smsapi.free-mobile.fr/sendmsg?user="YourFreeMobileIdentifierHere"&pass="YOURPASSHERE"&msg=" + message;
                var request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
            }
            catch(WebException e)
            {
                System.Diagnostics.Trace.WriteLine("SMS Not Sent! Exception "+e.ToString());
            }
            
        }
