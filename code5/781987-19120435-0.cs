    public class Base
    {
        public virtual object Clone()
        {
            Base copy = (Base)Activator.CreateInstance(this.GetType());
            copy.Id = this.Id;
            return copy;
        }
        public string Id { get; set; }
    }
    public class A : Base
    {
        public override object Clone()
        {
            A copy = (A)base.Clone();
            copy.Name = this.Name;
            return copy;
        }
        public string Name { get; set; }
    }
    A a = new A();
    A aCopy = (A)a.Clone();
