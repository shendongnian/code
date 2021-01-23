    private readonly Mock<IRepository> _testRepository;
    private readonly Mock<SubmissionVersion> _submissionVersion;
    private readonly Note _testNote;
    
    public MyTestClass()
    {
       _submissionVersion = new Mock<SubmissionVersion>();
       _testNote = new Note { Id = Guid.NewGuid() };
       _testRepository = new Mock<IRepository>();
       _testRepository.Setup(r => r.GetById<Note>(_testNote.Id).Returns(_testNote);
       _testRepository.Setup(r => r.GetById<SubmissionVersion>(It.IsAny<Guid?>())).Returns(_submissionVersion.Object);
    }
    
    [Fact]
    public void Should_CallSubmissionVerionNotesRemoveOnce()
    {
        // Arrange
        // done is setup
    
        // Act
        SubmissionVersion.DeleteNote(_testRepository.Object, _submissionVersion.Object, note.Id.Value);
    
        // Assert
        _submissionVersion.Verify(x => x.Notes.Remove(note), Times.Once());
    }
    
    [Fact]
    public void Should_CallRepoSaveSubmissionVersionOnce()
    {
        // Arrange
        // in setup
    
        // Act
        SubmissionVersion.DeleteNote(repo.Object, subVersion.Object, note.Id.Value);
    
        // Assert
        _testRepository.Verify(r => r.Save(_submissionVersion.Object), Times.Once());
    }
