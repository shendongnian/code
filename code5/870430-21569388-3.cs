    [Fact]
    public void Test()
    {
        var fixture = new Fixture();
        // (You may also include other customizations here.)
        fixture.Customizations.Add(
            new FilteringSpecimenBuilder(
                new Postprocessor(
                    new MethodInvoker(
                        new ModestConstructorQuery()),
                    new OfferFiller()),
                new OfferSpecification()));
        var offer = fixture.Create<Offer>();
        // -> offer.CompanyHistory has the value supplied in OfferFiller command.
    }
