    public class MyTest
    {
        private string name = "qwe";
        public virtual string Name { get { return name; } }
    }
    
    public class yourJs : MyTest
    {
        private string name = "chah";
        public override string Name { get { return name; } }
    }
