    [Fact]
    public void Test()
    {
        var fixture = new Fixture();
        fixture.Customize<Plane>(c => c
            .With(x => x.Id, fixture.Create<PlaneId>()));
        fixture.Customize<Car>(c => c
            .With(x => x.Id, fixture.Create<CarId>()));
        var plane = fixture.Create<Plane>();
        var car = fixture.Create<Car>();
        Assert.IsType<PlaneId>(plane.Id);
        Assert.IsType<CarId>(car.Id);
    }
