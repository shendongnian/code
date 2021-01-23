       JavaScriptSerializer js = new JavaScriptSerializer();
       var Data = DeserializeFromJson<ClassName>("Json String");
     public T DeserializeFromJson<T>(string json)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ObjJSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            T deserializedProduct = ObjJSerializer.Deserialize<T>(json);
            return deserializedProduct;
        }
