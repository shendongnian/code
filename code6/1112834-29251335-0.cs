    var getSomething = typeof(BaseClass)
           // get GetSomething<T> using reflection
           .GetMethod("GetSomething", BindingFlags.NonPublic | BindingFlags.Static) 
           // make it into GetSomething<Response>
           .MakeGenericMethod(typeof(Response)); 
    // and arrange
    Mock.NonPublic.Arrange<bool>(method,
            ArgExpr.IsAny<HttpWebRequest>(),
            ArgExpr.Out(successfullLoginResponse))
       .Returns(true);
