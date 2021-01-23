    public class Base<T> where T: Base<T>, new()
    {
        public virtual T Clone() 
        { 
            T copy = new T();
            copy.Id = this.Id;
            return copy;
        }
        public string Id { get; set; }
    }
    public class A : Base<A>
    {
        public override A Clone()
        {
            A copy = base.Clone();
            copy.Name = this.Name;
            return copy;
        }
        public string Name { get; set; }
    }
    private void Test()
    {
        A a = new A();
        A aCopy = a.Clone();
    }
