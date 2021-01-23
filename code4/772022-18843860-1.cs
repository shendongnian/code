    var state = 0;
    var substitute = Substitute.For<IFoo>();
    Action<CallInfo>[] onBar = {c => state++};
    substitute.When(s => s.Bar()).Do(c => onBar[0](c));
    substitute.Bar();
    Assert.That(state, Is.EqualTo(1));
    onBar[0] = c => state--;
    substitute.Bar();
    Assert.That(state, Is.EqualTo(0));
