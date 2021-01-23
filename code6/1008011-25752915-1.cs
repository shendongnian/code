     [TestMethod]
     public async Task PieName_WhenGettingException_ShouldHandleExceptionGracefully()
     {
          _pieMocker.Stub(x => x.GetDeliciousPieAsync()).Throws(new RottenFruitException());  
          await  _pickles.InitializePieAsync();
          var pieName = _pickles.PieName;
          Assert.IsNotNull(pieName);
     }
