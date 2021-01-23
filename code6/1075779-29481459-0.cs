    public class Parent
    {
        public Parent()
        {
            Child = new Child();
        }
        public string Text { get; set; }
        public Child Child { get; set; }
    }
