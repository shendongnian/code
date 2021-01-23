     [Test(Description = "to ")] 
     public void ClearIPHighlightingTets()
     {
        // Arrange
        HighlightType? type = null;
        UniformGridHighlighting.HighlightingChanged += x => { type = x; };
        //Act
        UniformGridHighlighting.ClearIPHighlighting();
        //Assert:
        Assert.AreEqual(s, HighlightType.IP);
     }
