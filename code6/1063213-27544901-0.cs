    [Theory, TestConventions]
    public void ShouldGetItemWithSameId(
        [Frozen]Mock<IDataFacade> facadeStub,
        BusinessLogic sut,
        int expected)
    {
        facadeStub
            .Setup(c => c.Get(It.IsAny<int>()))
            .Returns((int i) => new Item { Key = i });
        var result = sut.Get(expected);
        var actual = result.Key;
            
        Assert.Equal(expected, actual);
    }
