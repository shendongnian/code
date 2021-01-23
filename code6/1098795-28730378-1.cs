    [TestMethod]
    public void DeepCloneParent()
    {
        Mapper.CreateMap<Parent, Parent>();
        Mapper.CreateMap<Level1, Level1>();
        Mapper.CreateMap<Level2, Level2>();
        var parent = Parent.GetInstance();
            
        var copy = Mapper.Map<Parent, Parent>(parent);
            
        Assert.IsFalse(copy == parent);//diff object
        Assert.IsFalse(copy.Level1 == parent.Level1);//diff object
        Assert.IsFalse(copy.Level1.Level2 == parent.Level1.Level2);//diff object
        Assert.AreEqual("1", copy.Field1);
        Assert.AreEqual("2", copy.Level1.Field2);
        Assert.AreEqual("3", copy.Level1.Level2.Field3);
    }
