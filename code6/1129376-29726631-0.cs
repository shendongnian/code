    public class RootObject
    {
        public Company company { get; set; }
        public class Company
        {
            public Inner oltpid { get; set; }
        }
        public class Inner {
            public string Column1 { get; set; }  
        }
    }
    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);
    var result = obj.company.oltpid.Column1
