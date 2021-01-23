    var url = "http://echo.jsontest.com/MyProperty/MyValue"; // great testing site!
    var x1 = await GetJsonAsync<dynamic>(url);
    Assert.AreEqual("MyValue", x1.MyProperty); // fail!
    
    dynamic x2 = await GetJsonAsync<dynamic>(url);
    Assert.AreEqual("MyValue", x2.MyProperty); // fail!
    
    dynamic x3 = await GetJsonAsync<ExpandoObject>(url);
    Assert.AreEqual("MyValue", x3.MyProperty); // pass!
