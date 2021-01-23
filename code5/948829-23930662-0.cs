     [Test(Description = "to ")] 
     public void ClearIPHighlightingTets()
     {
        // Arrange
        bool eventTriggered = false;
        UniformGridHighlighting.HighlightingChanged += _ => { eventTriggered= true; };
        //Act
        UniformGridHighlighting.ClearIPHighlighting();
        //Assert:
        Assert.IsTrue(eventTriggered);
     }
