    public class Parent
    {
        public Parent(Child ch)
        {
            this.Child = ch;
            this.Child.Parent = this;
        }
 
        public Child Child {get; set;}
    }
