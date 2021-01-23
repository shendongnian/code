     public string PurchaseItem(string receiptData)
    {
        string returnmessage = "";
        try
        {
           // var json = "{ 'receipt-data': '" + receiptData + "'}";
            var json = new JObject(new JProperty("receipt-data", receiptData)).ToString();
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = Encoding.UTF8.GetBytes(json);
          //  HttpWebRequest request;
            var request = System.Net.HttpWebRequest.Create("https://sandbox.itunes.apple.com/verifyReceipt");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postBytes.Length;
            //Stream postStream = request.GetRequestStream();
            //postStream.Write(postBytes, 0, postBytes.Length);
            //postStream.Close();
            using (var stream = request.GetRequestStream())
            {
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Flush();
            }
          //  var sendresponse = (HttpWebResponse)request.GetResponse();
            var sendresponse = request.GetResponse();
            string sendresponsetext = "";
            using (var streamReader = new StreamReader(sendresponse.GetResponseStream()))
            {
                sendresponsetext = streamReader.ReadToEnd().Trim();
            }
            returnmessage = sendresponsetext;
        
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
        return returnmessage;
