    Mock.Arrange(() => _uowMock.Class.Add(
        Arg.Matches<ModelClass>(x => (CheckArgs(x, updated)))))
        .DoNothing().Occurs(3);
....
    protected static bool CheckArgs(ModelClass x, int y)
    {
        if (x.val != y)
        {
            Assert.Fail("Houston we have a problem");
        }
    
        return true;
    }
