    int state = 0;
    var substitute = Substitute.For<IFoo>();
    substitute.When(s => s.Bar()).Do(c => state++);
    substitute.Bar();
    Assert.That(state, Is.EqualTo(1));
    substitute.When(s => s.Bar()).Do(c => state--);
    substitute.Bar();
    // FAIL: Both Do delegates are executed and state == 1
    Assert.That(state, Is.EqualTo(0));
