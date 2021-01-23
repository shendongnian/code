    [Test]
    public void RemoveChildTagThrowsExceptionWhenNoChildren()
    {
        // Arrange
        var tag = new Tag();
        var tagToRemove = new Tag();
    
        // Act & Assert
        Expect(() => tag.RemoveChildTag(tagToRemove), Throws.ArgumentException);
    }
