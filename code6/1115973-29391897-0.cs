      MyResponse myResponse = null;
      HttpWebRequest httpWebRequest = System.Net.WebRequest.Create(requestUrl) as HttpWebRequest;
      using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
      {
        if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            throw new Exception(string.Format("Server error (HTTP {0}: {1}).", httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
        Stream stream = httpWebResponse.GetResponseStream());
        using (StreamReader streamReader = new StreamReader(stream))
        {
            myResponse = JsonConvert.DeserializeObject<MyResponse>(streamReader.ReadToEnd());
        }
      }
      return myResponse;
    [DataContract]
    class MyResponseClass
    {
        [DataMember]
        public Response response { get; set; }
    }
    [DataContract]
    public class Response
    {
        [DataMember(Name = "records")]
        public IDictionary<string, Record> Records { get; set; }
    }
    [DataContract]
    public class Record
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
