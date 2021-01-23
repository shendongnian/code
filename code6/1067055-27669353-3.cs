    [Fact]
    public void Container_Always_ContainsNoDiagnosticWarnings()
    {
        var container = this.ContainerFactory();
        container.Verify();
        var results = Analyzer.Analyze(container);
        Assert.False(results.Any());
    }
