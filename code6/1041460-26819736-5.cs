        using System.Web.Script.Serialization;
        public static string SerializeListAsJsonData<T>(List<T> list)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer()
            {
                //MaxJsonLength = _maxJsonLength, <-- This is optional (used for large lists)
            };
            return jsSerializer.Serialize(list);
        }
