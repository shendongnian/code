    public class MyTest {
        protected string name = "qwe";   // This is the ONLY name field, visible by inherited classes
        public string Name {
            get { return this.name; }
        }
    }
    public class yourJs: MyTest {
        public yourJs() {
            name = "chah";              // Change the value of MyTest.name
            base.name = "chah";         // Same as above, but explicit useage of base class MyTest
        }
    }
