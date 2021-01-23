    [HttpPost]
    public HttpResponseMessage MyMethod(MyViewModel model)
    {
        string a = "hello world!";
        return new HttpResponseMessage() { Content = new StringContent(a) };
    }
