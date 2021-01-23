    public class MyTest
    {
        private string name = "qwe";
        public string Name { get { return name; } }
    }
    
    public class yourJs : MyTest
    {
        private string name = "chah";
        public new string Name { get { return name; } }
    }
