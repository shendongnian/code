    public static class Helper
    {
        public  static string GetResponseData(object root,bool isJson)
        {
            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings {  ContractResolver = new ShouldSerializeContractResolver()});
            
            if (!isJson)
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(json,"response");
                json = doc.OuterXml;
            }
            return json;
        }
    }
