    public class MyTest
    {
        protected string name = "qwe";   // the name field
        public string Name   // the Name property
        {
            get
            {
                return this.name;
            }
        }
    }
    public class yourJs : MyTest
    {
        public yourJs()
        {
            name = "chah";
        }
    }
