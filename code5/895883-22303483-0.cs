    using System.Web.Script.Serialization;
    public static class JsonParser() {
         public string ParseJson(object obj) {
         return new JavaScriptSerializer().Serialize(obj);
         }
    }
