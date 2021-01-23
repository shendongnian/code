    [Serializable]
            [DataContract]
            public class ListData1
            {
                [DataMember]
                public string r0 { get; set; }
                [DataMember]
                public string r1 { get; set; }
                [DataMember]
                public string r2 { get; set; }
                [DataMember]
                public List<Data1> optdata { get; set; }
    
                public ListData1() { }
    
                public string ToJson()
                {
                    return JSONHelper.Serialize<ListData1>(this);
                }
            }
    
       [Serializable]
            [DataContract]
            public class Data1
            {
                [DataMember]
                public string label { get; set; }
                [DataMember]
                public string d0 { get; set; }
                [DataMember]
                public string d1 { get; set; }
    
                public Data1() { }
    
                public string ToJSON()
                {
                    return JSONHelper.Serialize<Data1>(this);
                }
            }
            [Serializable]
            [DataContract]
            public class ListData2
            {
                [DataMember]
                public string r0 { get; set; }
                [DataMember]
                public string r1 { get; set; }
                [DataMember]
                public string r2 { get; set; }
                [DataMember]
                public List<Data2> optdata { get; set; }
    
                public ListData2() { }
    
                public string ToJson()
                {
                    return JSONHelper.Serialize<ListData2>(this);
                }
            }
    
     [Serializable]
            [DataContract]
            public class Data2
            {
                [DataMember]
                public string label { get; set; }
                [DataMember]
                public string d0 { get; set; }
                [DataMember]
                public string d1 { get; set; }
                [DataMember]
                public string d2 { get; set; }
    
                public Data2() { }
    
                public string ToJSON()
                {
                    return JSONHelper.Serialize<Data2>(this);
                }
            }
     public static class JSONHelper
        {
            public static string Serialize<T>(T obj)
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                MemoryStream ms = new MemoryStream();
                serializer.WriteObject(ms, obj);
                string retVal = Encoding.UTF8.GetString(ms.ToArray());
                return retVal;
            }
    
            public static T Deserialize<T>(string json)
            {
                if (string.IsNullOrEmpty(json))
                {
                    return default(T);
                }
                T obj = Activator.CreateInstance<T>();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
                return obj;
            }
        }
           
