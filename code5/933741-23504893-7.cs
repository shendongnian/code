    [Fact]
    public void CreateImplA()
    {
        var fixture = new Fixture().Customize(new BaseCustomization());
        var actual = fixture.Create<BaseImplA>();
        Assert.NotEqual(default(string), actual.Text);
        Assert.NotEqual(default(int), actual.Value);
    }
    [Fact]
    public void CreateImplB()
    {
        var fixture = new Fixture().Customize(new BaseCustomization());
        var actual = fixture.Create<BaseImplB>();
        Assert.NotEqual(default(string), actual.Text);
        Assert.Equal(1, actual.Value);
    }
    [Fact]
    public void CreateBase()
    {
        var fixture = new Fixture().Customize(new BaseCustomization());
        var actual = fixture.CreateMany<Base>(4).ToArray();
        Assert.IsAssignableFrom<BaseImplA>(actual[0]);
        Assert.NotEqual(default(string), actual[0].Text);
        Assert.NotEqual(default(int), actual[0].Value);
        Assert.IsAssignableFrom<BaseImplB>(actual[1]);
        Assert.NotEqual(default(string), actual[1].Text);
        Assert.Equal(1, actual[1].Value);
        Assert.IsAssignableFrom<BaseImplA>(actual[2]);
        Assert.NotEqual(default(string), actual[2].Text);
        Assert.NotEqual(default(int), actual[2].Value);
        Assert.IsAssignableFrom<BaseImplB>(actual[3]);
        Assert.NotEqual(default(string), actual[3].Text);
        Assert.Equal(1, actual[3].Value);
    }
