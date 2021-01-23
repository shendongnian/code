    [Test]
    public void SomeMethod_NullSomething_ShouldThrow() {
        var something = MakeTarget();
    
        Assert.Throws<ArgumentNullException>(() => something.SomeMethod(null));
    }
