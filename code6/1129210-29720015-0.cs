    //remove the converter from here
    public class A
    {
        public A()
        {
            this.b = new B();
        }
        public int id { get; set; }
        public string name { get; set; }
        [JsonConverter(typeof(FJson))] 
        public B b { get; set; }
    }
