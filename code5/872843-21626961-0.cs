    public class MyData { public string Value; }
    public class MyRef  { public MyData Instance; }
    void Change()
    {
     var dataFoo = new MyData() { Value = "foo" }
     var dataBar = new MyData() { Value = "bar" }
     var referer = new MyRef()  { Instance = dataFoo }
     var list= new List<MyRef>();
     list.add(referer);
     list.add(referer);
     list.add(referer);
     // for i=0 to 2 -> list[i].Instance.Value = "foo"
     referer.Instance = dataBar;
     // for i=0 to 2 -> list[i].Instance.Value = "bar"
    }
