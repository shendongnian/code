    class Program
        {
            static void Main(string[] args)
            {
                DomainVerify verify = new DomainVerify() { domain = "test", key = "myKey", mailbox = "Newkey" };
                Console.WriteLine(GetJsonString(verify));
                Console.ReadLine();
                
            }
    
            public static string GetJsonString(object o)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(o.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    ser.WriteObject(ms, o);
                    string jsonData = Encoding.Default.GetString(ms.ToArray());                
                    return jsonData;
                }
            }
        }
    
        [DataContract]
        public class DomainVerify
        {
            [DataMember]
            internal string key { get; set; }
            [DataMember]
            public string domain { get; set; }
            [DataMember]
            public string mailbox { get; set; }
        }
