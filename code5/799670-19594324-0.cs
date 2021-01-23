    [Test]
    public void Transform_NonNullOptionObject_ValuePropertyIsTheSame()
    {
        OptionObjectTransform transform = InitTransform();
        CustomOptionObject result = transform.Transform(optionObject);
        var expected = new[] { optionObject.Value, optionObject.FormCode };
        var actual = new[] { result.Value, result.FormCode };
        Assert.AreEqual(expected, actual);
    }
