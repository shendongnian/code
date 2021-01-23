     we can include below line of code in test clean up method to re run the     failed  script
    if (TestContext.CurrentTestOutCome==TestContext.unittestoutcome.failed)
    {
      var type=Type.GetType(TestContext.FullyQualifiedTestClassName);
      if (type !=null)
       {
         var method=Type.GetMethod(TestContext.TestName);
         var event=Activator.CreateInstance(type);
       }
     method.invoke(event);
  
}
