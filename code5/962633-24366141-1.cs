    [Test]
    public void RemoveChildTagRemovesPreviouslyAddedChild()
    {
        // Arrange
        var tag = new Tag();
        var childTag = new Tag();
        tag.AddChildTag(childTag);
        // Act
        tag.RemoveChildTag(childTag);
        // Assert
        Expect(tag.Children.Contains(childTag), Is.False);
    }
