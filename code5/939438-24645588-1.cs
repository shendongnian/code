    class Program
    {
        static void Main(string[] args)
        {
            string countiesJson = "{'Everything':[{'county_name':null,'description':null,'feat_class':'Civil','feature_id':'36865',"
                    +"'fips_class':'H1','fips_county_cd':'1','full_county_name':null,'link_title':null,'url':'http://www.alachuacounty.us/','name':'Alachua County'"+ ",'primary_latitude':'29.7','primary_longitude':'-82.33','state_abbreviation':'FL','state_name':'Florida'},"+
                    "{'county_name':null,'description':null,"+ "'feat_class':'Civil','feature_id':'36866','fips_class':'H1','fips_county_cd':'3','full_county_name':null,'link_title':null,'url':'http://www.bakercountyfl.org/','name':'Baker County','primary_latitude':'30.33','primary_longitude':'-82.29','state_abbreviation':'FL','state_name':'Florida'}]}";
            foreach (County c in JsonParseCounties(countiesJson))
            {
                Console.WriteLine(string.Format("{0}, {1} ({2},{3})", c.name, 
                   c.state_abbreviation, c.primary_latitude, c.primary_longitude));
            }
        }
        public static List<County> JsonParseCounties(string jsonText)
        {
            return JsonConvert.DeserializeObject<RootObject>(jsonText).Counties;
        }
    }
    public class RootObject
    {
        [JsonProperty("Everything")]
        public List<County> Counties { get; set; }
    }
    public class County
    {
        public string county_name { get; set; }
        public string description { get; set; }
        public string feat_class { get; set; }
        public string feature_id { get; set; }
        public string fips_class { get; set; }
        public string fips_county_cd { get; set; }
        public string full_county_name { get; set; }
        public string link_title { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string primary_latitude { get; set; }
        public string primary_longitude { get; set; }
        public string state_abbreviation { get; set; }
        public string state_name { get; set; }
    }
