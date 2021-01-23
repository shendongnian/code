    protected void SerializeItem(string s){
    System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
    RootObject rt = js.Deserialize<RootObject>(s);//deserialization from string to object
     string S = js.Serialize(RootObject);//serialization from object to complex json string
    }
