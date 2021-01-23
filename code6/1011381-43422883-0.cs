    var meetingData = new List<MeetingInfo>();
    //...populate the list with data
    var mockList = new Mock<IMeetingList>();
    mockList.As<IQueryable<MeetingInfo>>().Setup(m => m.Provider).Returns(meetingData.Provider);
    mockList.As<IQueryable<MeetingInfo>>().Setup(m => m.Expression).Returns(meetingData.Expression);
    mockList.As<IQueryable<MeetingInfo>>().Setup(m => m.ElementType).Returns(meetingData.ElementType);
    mockList.As<IQueryable<MeetingInfo>>().Setup(m => m.GetEnumerator()).Returns(() => meetingData.GetEnumerator());
