    public class Test
    {
        public int Test1 { get; set; }
        public int Test2 { get; set; }
        public int Test3 { get; set; }
        public Test()
        {
            Test1 = -1;
        }
    }
    var t =  new Test
        {
            Test2 = var2,
            Test3 = var3
        };
    if (var1 != null) // or (var1.HasValue)
        t.Test1 = var1.Value;
