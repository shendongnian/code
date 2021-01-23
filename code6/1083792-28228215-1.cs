    private static bool myProp; // cant be accessed on the Program Type
    public static bool MyProp { get; set; } // can be accessed on the Program Type
    class MyClass
    {
        public MyClass()
        {
            Program.MyProp = true;
            Program.MyProp = true; // wont build
        }
    }
