    class OrderAttribute : Attribute
    {
        public int Order { get; private set; }
        public OrderAttribute(int order)
        {
            this.Order = order;
        }
    }
    class A
    {
        public string FieldWithoutOrder;
        [Order(3)] public string Field1;
        [Order(2)] public string Field2;
        [Order(1)] public string Field3;
    }
    static void Main(string[] args)
    {
        A myA = new A() { Field1 = "rofl", Field2 = "lol", Field3 = "omg", FieldWithoutOrder = "anarchy" };
        var obj = (from prop in typeof(A).GetFields(BindingFlags.Public | BindingFlags.Instance)
                   orderby prop.GetCustomAttributes(typeof(OrderAttribute),true).Select(att=>((OrderAttribute)att).Order).DefaultIfEmpty(Int32.MaxValue).First()
                   select prop.GetValue(myA)
                    ).ToArray();
        var obj2 = (from prop in typeof(A).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   select prop.GetValue(myA,null)).ToArray();
        Debug.Assert(obj[0] == "omg"); //Field3
        Debug.Assert(obj[1] == "lol"); //Field2
        Debug.Assert(obj[2] == "rofl"); //Field1
        Debug.Assert(obj[3] == "anarchy"); //FieldWithoutOrder
    }
