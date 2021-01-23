    public class MyTest
    {
        private string name = "jhon";
        public string Name { get { return name; } }
    }
    
    public class yourJs : MyTest
    {
        private string name = "tim";
        public new string Name { get { return name; } }
    }
