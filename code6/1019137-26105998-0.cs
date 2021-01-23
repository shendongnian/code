    public abstract class MyClass
    {
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public class Mutable : MyClass
        {
            public new string Title { get { return base.Title; } set { base.Title = value; } }
            public new string Author { get { return base.Author; } set { base.Author = value; } }
        }
    }
