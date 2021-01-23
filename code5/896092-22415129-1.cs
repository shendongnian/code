    private void whenEventRaised_someStuffHappens(){
        PrivateType eventOriginType = new PrivateType(typeof(EventOrigin));
        eventOriginType.InvokeStatic("raiseEventOccurred", "arg1", "arg2");
        Assert.IsTrue(overthinkingTheProblemIsDangerous);
    }
