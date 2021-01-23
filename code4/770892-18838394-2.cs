    public void Test()
    {
        Dictionary<string, Func<string, Player, MyResult>> functions = new Dictionary<string, Func<string, Player, MyResult>>();
        functions.Add("Say",CreateFunction("doSay"));
        var result = functions["Say"]("Hello", new Player());
    }
    public Func<string, Player, MyResult> CreateFunction(string methodName)
    {
        if (this.GetType().GetMethods().Any(x => x.Name == methodName))
        {
            return new Func<string, Player, MyResult>((arg1, arg2) => (MyResult)this.GetType().GetMethod(methodName).Invoke(this, new object[] { arg1, arg2 }));
        }
        return null;
    }
    public MyResult doSay(string value1, Player value2)
    {
        return new MyResult(value1, value2);
    }
    public class MyResult
    {
        public MyResult(string value1, Player value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public string Value1 { get; set; }
        public Player Value2 { get; set; }
    }
