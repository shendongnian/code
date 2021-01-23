    public class MyObject { public string attr1 { get; set; } }
    public class class1
    {
        public static MyObject MyVar // <-- here
        {
            get;
            private set; // <-- made private to prevent changes from the outside
        }
        // public static MyObject getVar() // use MyVar instead
        //{
        //    return MyVar;
        //}
        public static class1() // <-- here
        {
            Debug.WriteLine("kjkjkj");
            MyVar = new MyObject();
            MyVar.attr1 = "test init";
        }
    }
