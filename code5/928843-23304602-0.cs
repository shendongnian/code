    [Test()]
    public void IsChildOfTest()
    {
        var dog = new Dog();
        var isAnimal = dog is Animal;
        Assert.IsTrue(isAnimal);
    }
