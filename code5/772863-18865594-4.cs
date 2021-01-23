    ViewResult vResult = result as ViewResult;
    if(vResult != null)
    {
      Assert.IsInstanceOfType(vResult.Model, typeof(YourModelType));
      YourModelType model = vResult.Model as YourModelType;
      if(model != null)
      {
        //...
      }
    }
  
