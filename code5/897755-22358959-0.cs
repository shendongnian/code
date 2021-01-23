    private void Form3_Load(object sender, EventArgs e)
        {
            Parent parent = new Parent();
            parent.Child = new List<Child>(); // -> this is where implementer is decided.  
            //Before this line, Child property is not instantiated and is not referring to any object.
        }
        public class Parent
        {
            public IEnumerable<Child> Child { get; set; }
        }
        public class Child
        {
            public int MyProperty { get; set; }
        } 
