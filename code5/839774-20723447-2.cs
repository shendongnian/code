    [Theory, BasicConventions]
    public void GetVersionOnSiteVersionControllerReturnsASiteVersion(
        SiteVersionController sut,
        SiteVersion expected)
    {
        SiteVersion actual = null;
        var response = sut
            .GetSiteVersion()
            .ExecuteAsync(new CancellationToken())
            .Result
            .TryGetContentValue<SiteVersion>(out actual);
        actual.AsSource().OfLikeness<SiteVersion>().ShouldEqual(expected);
    }
