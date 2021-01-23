    class Parent
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class Child : Parent
    {
        public string Note { get; set; }
    }
    class Factory
    {
        public static Parent MakeParent()
        {
            var parent = new Parent();
            Initialize(parent);
         
            return parent;
        }
        private static void Initialize(Parent parent)
        {
            parent.Name = "Joe";
            parent.ID = 42;
        }
        public static Child MakeChild()
        {
            var child = new Child();
            Initialize(child);
            child.Note = "memento";
            return child;
        }
    }
