    [WebMethod]
        public static void addUser(string Params)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var oParamter =  serializer.Deserialize<Paramter>(Params);
        }
        private class Paramter
        {
            public string id { get; set; }
            public string name { get; set; }
        }
