    [Test]
    public void ClimbOnceTwoNeighbour_Sample()
    {
        stateConverter = new Mock<StateConverter>();
    
        solution = new Mock<Solution>();
        state = new Mock<State>();
    
        var neightbourSolution1 = new Mock<Solution>();
        var neighbourState1 = new Mock<State>();
        var neightbourSolution2 = new Mock<Solution>();
        var neighbourState2 = new Mock<State>();
    
        stateConverter.Setup(x => x.FromSolution(neightbourSolution1.Object, It.IsAny<State>())).Returns(neighbourState1.Object);
    var state1 = stateConverter.Object.FromSolution(neightbourSolution1.Object, state.Object);//return null ????
    
    
        stateConverter.Setup(x => x.FromSolution(neightbourSolution2.Object, It.IsAny<State>())).Returns(neighbourState2.Object);
        var state2 = stateConverter.Object.FromSolution(neightbourSolution2.Object, state.Object);//return neighbourState2.Object)
    
    
        Assert.AreEqual(neighbourState2.Object, state2);//pass test here
        Assert.AreEqual(neighbourState1.Object, state1);//fail here due to null is returned from previous statement
    
    }
