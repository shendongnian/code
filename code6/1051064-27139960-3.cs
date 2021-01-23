    public class DomainVerify
        {
            [Newtonsoft.Json.JsonProperty]  // if you don't mark this attribute then as this is internal property it will not serilize.
            internal string key { get; set; }
            [Newtonsoft.Json.JsonProperty] // as this is public property it always include in serilization unless you mark it with JsonIgnore.
            public string domain { get; set; }
            [Newtonsoft.Json.JsonProperty]
            public string mailbox { get; set; }
        }
    
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
                return JsonConvert.SerializeObject(o);
            }
         }
