    [Test]
    public void Blah() {
        var thing = new Thing();
        mockRouter.Route(Arg.Is<Transition<Thing>>(x => HasSubject(x, thing)));
        // ...
        var result = handler.Handle(thing);
        // ...
        mockRouter.Received(1).Route(Arg.Is<Transition<Thing>>(x => HasSubject(x, thing)));
    }
    private bool HasSubject(Transition<Thing> x, Thing thing) {
        return x != null && x.Subject != null && x.Subject.Equals(thing));
    }
    //or...
    [Test]
    public void Blah2() {
        var thing = new Thing();
        mockRouter.Route(ArgWith(thing));
        // ...
        var result = handler.Handle(thing);
        // ...
        mockRouter.Received(1).Route(ArgWith(thing));
    }
    private Transition<Thing> ArgWith(Thing thing) {
        return Arg.Is<Transition<Thing>>(x => x != null && x.Subject != null && x.Subject.Equals(thing));
    }
