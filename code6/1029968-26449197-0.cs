    [TestMethod]
    [ExpectedException(typeof(MeetingNullException))]
    public void MeetingNoteSave_WithNotExistingMeeting()
    {
        _repository.MeetingNoteSave(1, "My note", true, "xxx@xxx.com");
    }
    
    [TestMethod]
    [ExpectedException(typeof(MeetingFutureException ))]
    public void MeetingNoteSave_WithFutureDate()
    {
        _repository.MeetingNoteSave(1, "My note", true, "xxx@xxx.com");
    }
