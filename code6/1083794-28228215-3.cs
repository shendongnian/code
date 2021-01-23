    private static bool myProp; // can't be accessed on the Program Type
    public static bool MyProp { get; set; } // can be accessed on the Program Type
    class MyClass
    {
        public MyClass()
        {
            Program.MyProp = true;
            Program.myProp= true; // wont build
        }
    }
