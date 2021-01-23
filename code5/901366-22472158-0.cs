    using System.Web.Script.Serialization;
    
    public List<String> samplelist
    {
         get { return samplelist; }
         set { samplelist = value; }
    }
    public string sampleListJson()
    {
        var jsonSerializer = new JavaScriptSerializer();
        return jsonSerializer.Serialize(samplelist);
    }
