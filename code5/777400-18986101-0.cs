        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            return serializer.Serialize(obj);
        }
    public string GetData()
    {
        return (new {SomeData}).ToJson();
    }
