    public class ClassA
    {
        [Editor(typeof(MyCollectionEditor), typeof(UITypeEditor))]
        public List<ClassB> List { get; set; }
    }
