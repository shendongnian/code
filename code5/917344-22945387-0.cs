    [Fact]
    public void GroupReportIsReturnedWithSomeData()
    {
         GroupReportIsReturnedWithSomeDataAsync().Wait();
    }
    private async Task GroupReportIsReturnedWithSomeDataAsync()
    {
        // arrange
        var sut = new Client();
        // act
        var actual = await sut.GetReportGroupAsync();
        // assert
        // Xunit test
        Assert.Null(actual);
        Assert.NotNull(actual);
        // FluentAssertions
        actual.Should().BeNull();
        actual.Should().NotBeNull();
    }
