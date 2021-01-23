    public void CheckRFID(string RFIDtag)
    {
        [...SOME WORKING CODE]
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string response = new StreamReader(response.GetResponseStream()).ReadToEnd();
        System.Diagnostics.Debug.WriteLine(response);  
        currentuser = Newtonsoft.Json.JsonConvert.DeserializeObject<User[]>(response);
        System.Diagnostics.Debug.WriteLine(currentuser[0].UserID);
    }
