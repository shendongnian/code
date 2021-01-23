    class Parent
    {
        public virtual int MyMethod()
        {
            return 1;
        }
    }
    class Child : Parent
    {
        public override int MyMethod()
        {
            return 2;
        }
    }
    class OtherChild : Parent
    {
        public new int MyMethod()
        {
            return 3;
        }
    }
    // ...
    Parent p = new Parent();
    Parent c = new Child();
    Parent oc = new OtherChild();
    int result;
    result = p.MyMethod(); // will return 1
    result = c.MyMethod(); // will return 2
    result = oc.MyMethod(); // will return 1
