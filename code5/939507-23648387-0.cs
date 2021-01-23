    public class Decorator1
    {
        public String Name { get; set; }
        public ObservableCollection<Object> Children { get; set; }
        public string Description { get; set; }
    }
    public class Decorator2
    {
        public long Id { get; set; }
    }
    public class ClassA
    {
        public Decorator1 TreeNodeImpl;
    }
    public class ClassB
    {
        public Decorator1 TreeNodeImpl;
        public Decorator2 LongIdImpl;
    }
