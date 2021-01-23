    string actualMyPropOnAdd = null;
    _store
        .Stub(s => s.Add(Arg<MyObj>.Is.Anything))
        .Do((Action<MyObj>)(myObj =>
        {
            // save the necessary properties to validate them later
            actualMyPropOnAdd = myObj.myProp;
        }));
    // call CreateAndProcess() here
    // validate saved properties:
    Assert.That(actualMyPropOnAdd, Is.EqualTo(expectedMyPropOnAdd));
