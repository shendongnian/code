    public void NotPaidBar_ThrowsException()
    {
        var allStates = Enum.GetValues(typeof (State)).Cast<State>();
        foreach (var state in allStates.Except(new[]{State.Paid}))
        {
            // Arrange
            var bar = new Bar()
            {
                State = state
            };
    
            var underTest = new UnderTest();
    
            // Act
            Action result = () => underTest.Foo(bar);
    
            // Assert
            result.ShouldThrow<Exception>();
        }
    }
