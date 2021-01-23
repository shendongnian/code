    [Setup]
    Public void Setup()
    {
        _dustcart = new Dustcart()
    }
    
    [TearDown] 
    public void TearDown ()
    {
      _dustcart.Dispose();
    }
    
    [TestMethod]
    public void TestUpload()
    {
       var stream = _dustcart.DisposeOnTearDown(FunctionCreatingTheMemoryStream());
       var file = new Mock<HttpPostedFileBase>();  
    
       file.Setup(f => f.FileName).Returns("test.txt");
       file.Setup(f => f.InputStream).Returns(stream);  
       MethodThatUsesTheStream(file.Object)
       // rest of test code with Assert
    }
