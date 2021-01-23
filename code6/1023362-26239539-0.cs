    public class MyClass
    {
        public string Attrib1 {get; set;}
        public string Attrib2 {get; set;}
        public List<InnerClass> Inners {get; set;}
        ...
    }
    
    public class InnerClass
    {
        ...
    }
    
    public void DoStuffWithInput(string input)
    {
        var myObject = JsonConvert.DeserializeObject<MyClass>(input);
        foreach (InnerClass inner in myObect.Inners)
        {
            var innerJson = JsonConvert.SerializeObject(inner);
            // do stuff
        }
    }
