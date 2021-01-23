    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void Controller_Index_ThrowsException()
    {
        var sut = new HomeController();
        sut.Index();
    }
