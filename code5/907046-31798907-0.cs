    public void TestUpload()
    {
      using (var stream = FunctionCreatingTheMemoryStream())
      {
        var file = new Mock<HttpPostedFileBase>();
        file.Setup(f => f.FileName).Returns("test.txt");
        file.Setup(f => f.InputStream).Returns(stream);  
        MethodThatUsesTheStream(file.Object)  
        // rest of test code with Assert
      }
    }
