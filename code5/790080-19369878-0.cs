    // [assembly:InternalsVisibleTo("Tests")]
    // is applied to the assembly that contains the 'Dummy' type
    [Fact]
    public void Test()
    {
        var fixture = new Fixture();
        var dummy = fixture.Create<Dummy>();
        dummy.Name = fixture.Create<string>();
        // ...
    }
