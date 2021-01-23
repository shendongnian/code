    void GivenImageAlreadyPresent()
    {
     mockModel.SetupProperty(m => m.Image, new Bitmap(100, 100));  
    }
    
    void WhenActiveImageReplaced()
    {
     mockMBox.Setup(mb => mb.ViewResult).Returns(ViewResult.OK);   
     mockView.Raise(v => v.UserRequestsNewImage += null);          
    }
    
    void ThenImageShouldBeReplaced()
    {
     mockView.Verify(v => v.OpenAddImageFileDialog(), Times.Once);
    }
    
    void Test()
    {
     GivenImageAlreadyPresent();
     WhenActiveImageReplaced();
     ThenImageShouldBeReplaced();
    }
