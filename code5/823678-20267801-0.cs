    public class Derived : Base
    {
        public Derived(string name) : base(name)
        { }
        public void Test()
        {
            //here, it's perfectly ok to access the protected Name.
        }
    }
