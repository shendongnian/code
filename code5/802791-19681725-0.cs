    JavaScriptSerializer js = new JavaScriptSerializer();
       var Data = DeserializeFromJson<Test>("Json String");
    public T DeserializeFromJson<T>(string json)
    {
        System.Web.Script.Serialization.JavaScriptSerializer ObjJSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        T deserializedProduct = ObjJSerializer.Deserialize<T>(json);
        return deserializedProduct;
    }
     public class Test
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
