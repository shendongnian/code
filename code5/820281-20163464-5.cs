    void Main()
    {
        Action a = Static.StaticMethod;
        (a.Target == null).Dump();
    }
    
    public static class Static
    {
        public static void StaticMethod() { }
    }
