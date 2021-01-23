    public class ValueModel
    {
        public Person value { get; set; }
    } 
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> activities { get; set; }
        public string favoriteHobby { get; set; }
    }
    public HttpResponseMessage Post([FromBody]ValueModel model) { .. }
