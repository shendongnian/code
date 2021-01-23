    [Fact]
    public void Controller_Index_ThrowsException()
    {
        var sut = new HomeController();
        Assert.Throws<Exception>(() => sut.Index());
    }
    [Fact]
    public void Controller_Index_DoesNotThrowException()
    {
        var sut = new HomeController();
        Assert.DoesNotThrow(() => sut.Index());
    }
