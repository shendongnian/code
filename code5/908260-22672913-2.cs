    public class MyClass
    {
        public int Id {get; set;}
        public string Title {get;set;}
        public string Html {get;set;}
        public string CSS {get;set;}
        public string SomethingElse {get;set;}
    }
    //Then create a dictionary.
    Dictionary<int, MyClass> MyDictionary=new Dictionary<int, MyClass)();
    // create an some instance of MyClass
    MyClass MyClassInstance=new MyClass(){Id=621, Title="A Title", Html="Some Html", CSS= "Some CSS", SomethingElse="Something else goes here"};
    //add it to your dictionary
    MyDictionary.Add(MyClassInstance.Id, MyClassInstance);
    //serialize it to JSON with Json.Net
    string somejson= JsonConvert.SerializeObject(MyDictionary);
