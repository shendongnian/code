    public class MyBaseClass
    {
        public MyBaseClass()
        {
            var type = this.GetType();
            Debug.WriteLine(type.BaseType.Name);
            // If this was called by ChildClass it would print MyBaseClass2
        }
    }
    public class MyBaseClass2 : MyBaseClass
    {
    }
    public class ChildClass : MyBaseClass2
    {
    }
