    [Test]
    public void TestIt()
    {
        var validator = new TestValidator(v => v.RuleFor(obj => obj.GenericDecimal).SetValidator( new MyValidator() ));
        Assert.IsTrue(validator.Validate(new TestObject(null)).IsValid);    
        Assert.IsTrue(validator.Validate(new TestObject(0m)).IsValid);   
        Assert.IsTrue(validator.Validate(new TestObject(3m)).IsValid);   
        Assert.IsFalse(validator.Validate(new TestObject(-1m)).IsValid);   
        Assert.IsFalse(validator.Validate(new TestObject(3.01m)).IsValid);   
    }
