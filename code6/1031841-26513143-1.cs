    public MyDictionary : Dictionary<string, int>
    {
    }
    var myDic = new MyDictionary();
    var context = HttpContext.GetOwinContext();
    context.Set(myDic);
    var myDic2 = context.Get<MyDictionary>();
