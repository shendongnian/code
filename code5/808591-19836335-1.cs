    public void CheckRFID(string RFIDtag)
    {
        [...SOME WORKING CODE]
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string responseString = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        System.Diagnostics.Debug.WriteLine(responseString);  
        currentuser = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(responseString);
        System.Diagnostics.Debug.WriteLine(currentuser[0].UserID);
    }
