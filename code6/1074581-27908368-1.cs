    public class Element
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string Commission {get; set;}
    }
    var data = new Dictionary<string,Element>();
    data.Add(e.ID,e); //assuming e is of type Element and defined.
