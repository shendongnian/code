    [Test]
    public void Foo()
    {
        // Arrange
        var seq1 = Enumerable.Range(0, 10);
        var seq2 = Enumerable.Range(0, 10);
        var seq3 = Enumerable.Range(0, 20);
    
        // Act
        // ...
    
        // Assert
        Assert.That(seq1, Is.EquivalentTo(seq2)); // OK
        Assert.That(seq1, Is.EquivalentTo(seq3)); // Not OK
    }
