    class A
    {
        public string Field1;
        public string Field2;
        public string Field3;
    }
    static void Main(string[] args)
    {
        A myA = new A() { Field1 = "rofl", Field2 = "lol", Field3 = "omg" };
        var obj = (from prop in typeof(A).GetFields(BindingFlags.Public | BindingFlags.Instance)
                    select prop.GetValue(myA)).ToArray();
        Debug.Assert(obj[0] == "rofl");
        Debug.Assert(obj[1] == "lol");
        Debug.Assert(obj[2] == "omg");
    }
