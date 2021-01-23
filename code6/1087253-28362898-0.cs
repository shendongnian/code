    [Fact]
    public void CustomizeParameter()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new FilteringSpecimenBuilder(
                new FixedBuilder("Ploeh"),
                new ParameterSpecification(
                    typeof(string),
                    "specialValue")));
        var actual = fixture.Create<MyClass>();
        Assert.Equal("Ploeh", actual.SpecialValue);
    }
