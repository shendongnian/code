    public class Parent
    {
        public class Child
        {
        }
        private Parent.Child myChild;
        public Parent.Child MyChild
        {
            get
            {
                return this.myChild;
            }
            set
            {
                this.myChild = value;
            }
        }
    }
