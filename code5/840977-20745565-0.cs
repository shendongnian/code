    [Test]
    public void CloneTest()
    {
        // create the mock
        var mdFake = new Mock<MachineDecision>();
        var decision = new Decision
        {
            // setup (pass it to my collection)
            MachineDecisions = new List<MachineDecision> { mdFake.Object }
        };
        
        // call the method being tested 
        decision.Clone();
        // check for the side effects -> It was called once !
        mdFake.Verify(x => x.Clone(), Times.Once());
    }
