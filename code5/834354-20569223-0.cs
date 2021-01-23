    // use like
    var rootObj = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
    foreach (var row in rootObj.rows)
    {
        foreach (var element in row.elements)
        {
            Console.WriteLine(element.distance.text);
        }
    }
    // you might want to change the property names to .Net conventions
    // use [JsonProperty] to let the serializer know the JSON names where needed
    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }
    
    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }
    
    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }
    
    public class Row
    {
        public List<Element> elements { get; set; }
    }
    
    public class RootObject
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }
