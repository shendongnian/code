    public class RootObject
    {
        public Company company { get; set; }
    }
    public class Company
    {
        public Oltpid oltpid { get; set; }
    }
    public class Oltpid
    {
        public string Column1 { get; set; }  
    }
    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);
    var result = obj.company.oltpid.Column1
