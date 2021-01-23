        [Fact]
        public void DeleteNote_Deletion_VerifyExpectedMethodsInvokecOnlyOnce()
        {
            // Arrange
            var note = new Note { Id = Guid.NewGuid() };
            var fakeSubmissionVersion = new SubmissionVersion() { Notes = new List<Note>() };
            var repo = new Mock<IRepository>();
            repo.Setup(x => x.GetById<Note>(It.IsAny<Guid>())).Returns(note);
           
            // Act
            NotesHelper.DeleteNote(repo.Object, fakeSubmissionVersion, note.Id.Value);
            // Assert
            repo.Verify(x => x.GetById<Note>(note.Id), Times.Once());
            repo.Verify(x => x.Save(fakeSubmissionVersion), Times.Once());
            repo.Verify(x => x.Delete(note), Times.Once());
        }
