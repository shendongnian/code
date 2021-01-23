    TestCast tc3 = new TestCast(5757);
    MyDic myDic = new MyDic();
    myDic.Add(tc3, "string");
    myDic[tc3] = "string2";
    public class MyDic : Dictionary<MyProperty, string>
    {
    }
