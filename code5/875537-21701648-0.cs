    public class MyPage : MyPageBase
    {
    public string TestAccessBaseProp()
    {
    var foo = base.ImagePath;
    }
    public string SomeAdditionalProperty { get; set; }
    }
