    [Fact]
    public void DeleteNote_RemoveNotes_ReturnsExpectedNotes()
    {
        // Arrange
        var note = new Note { Id = Guid.NewGuid() };
        var fakeSubmissionVersion = new SubmissionVersion() { Notes = new List<Note>() { note } };
        var repo = new Mock<IRepository>();
        repo.Setup(x => x.GetById<Note>(It.IsAny<Guid>())).Returns(note);
        // Act
        NotesHelper.DeleteNote(repo.Object, fakeSubmissionVersion, note.Id.Value);
        // Assert
        Assert.AreEqual(0, fakeSubmissionVersion.Notes.Count);
    }
