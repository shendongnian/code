    public void SomeMethod()
    {
        string json =
            "[\"sd\",[\"sdg\u0026e\",\"sdlc\",\"sdccu\"" + 
            ",\"sdsu webportal\",\"sdsu\",\"sdsu blackboard\","+
            "\"sdcc\",\"sd card\",\"sdn\",\"sdro\"]]";
        var factory = new Factory();
        var suggest = factory.Create(json);
        Console.WriteLine(suggest);
    }
    public class Factory
    {
        public SuggestClass Create(string json)
        {
            var array = JArray.Parse(json);
            string search = array[0].ToString();
            string[] terms = array[1].ToArray().Select(item => item.ToString()).ToArray();
           
            return new SuggestClass {Search = search, Terms = terms};
        }
    }
    public class SuggestClass
    {
        public string Search { get; set; }
        public IEnumerable<string> Terms { get; set; }
        public override string ToString()
        {
            return string.Format("Search={0},Terms=[{1}]", 
                Search, string.Join(",", Terms));
        }
    }
