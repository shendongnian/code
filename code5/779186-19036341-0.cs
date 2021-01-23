    void Main()
    {
        new MyClass{Title = "hi"}.ToJson().Dump();
    }
    
    // Define other methods and classes here
    public class MyClass {
        public string Title{get;set;}
        public override string ToString(){ return Title; }
        public string ToJson(){ 
            return JsonConvert.SerializeObject(this); 
        }
    }
