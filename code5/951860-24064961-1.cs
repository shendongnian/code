    public String Post([FromBody]TransactionDetails value, HttpRequestMessage receivedReq)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
                httpWebRequest.ContentType = "application/json; charset=UTF-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "key=AIzaSyBs_eh4nNVaJl3FjQ_ZC72ZZ6uQ2F8r8W4");
                String result = "";
                String yourresp = "<html><head><title>Response from Server</title></head><body>";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"data\":" +"{\"Amount\":"+value.Amount+","+
                                    "\"Account\":"+value.ToAccountNumber+"}"+","+
                                    "\"registration_ids\":[" + "\""+value.RegID +"\"]}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                         result = streamReader.ReadToEnd();
                    }
                }
                DialogResult result1 = MessageBox.Show("Server sent the details to your phone, Check and Confirm to Continue or Not", "Important Information",MessageBoxButtons.YesNo);
                if (result1.ToString().Contains("Yes"))
                {
                    WriteAccountNumber(value.ToAccountNumber, value.Amount);
                    yourresp += "<h1>The Transaction was Successful</h1>";
                    
                }
                else
                {
                    yourresp += "<h1>The Transaction was NOT Successful</h1>";
                }
                yourresp += "</body></html>";
                return yourresp;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured in Post Method on Web Server as:{0}", e.Message);
                return e.Message;
            }
        }
