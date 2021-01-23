    public class Parent
    {
        public Child {get; set;}
        public Parent()
        {
            Child = new Child(this);
        }
    }
