    public class MyBase
    {
        public virtual string MyProperty { get { return "Base"; } }
        public string MyBaseMethod()
        {
            return MyProperty;
        }
    }
    public class MyInherited : MyBase
    {
        public override string MyProperty { get { return "Inherited"; } }
    }
---
    var inherited = new MyInherited();
    Console.WriteLine(inherited.MyBaseMethod()); // ==> "Inherited"
