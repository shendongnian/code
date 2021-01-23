    var defaultMeeting = new Meeting() { Date = new DateTime() };
    
    var dateOfMeeting = meetingRepository.FindBy(s => s.FirstIdeaId == j.Id)
            .DefaultIfEmpty(defaultMeeting)
            .FirstOrDefault()
            .Date;
