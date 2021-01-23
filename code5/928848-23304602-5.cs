    [Test]
    public void IsChildOfTest()
    {
        var dog = new Dog();
        Assert.False(dog.GetType().IsSubclassOf(typeof(Dog)));
        Assert.True(dog is Dog);
    }
