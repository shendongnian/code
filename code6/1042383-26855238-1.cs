    public class MyBase
    {
        public int Id { get; set; }
    }
    public class FirstType : MyBase
    {
    }
    public class SecondType : MyBase
    {
    }
    var list = new List<MyBase>();
    list.Add(new FirstType());
    list.Add(new SecondType());
