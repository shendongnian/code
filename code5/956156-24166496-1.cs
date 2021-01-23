      public static TReturn GetPrivateField<TIn,TReturn>(TIn instance, 
                                                         string fieldName)
      {
         var fieldInfo = typeof(TIn).GetField(fieldName, BindingFlags.NonPublic | 
                                 BindingFlags.Instance);
         return (fieldInfo != null)
                   ? (TReturn)fieldInfo.GetValue(instance)
                   : default(TReturn);
      }
    
      [Test]
      public void EnsureMethod()
      {
         var mock = new Mock<IDependency>();
         var sut = new SystemUnderTest(mock.Object);
         sut.DoSomethingGoodWithTest();
    
         mock.Verify(x => x.Method(It.Is<Test>(
                         t => GetPrivateField<Test, int>(t, "_field") == 5)));
      }
