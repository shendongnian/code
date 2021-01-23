    var meeting = Meetings.TakeWhile(m => !m.Selected)
                          .LastOrDefault();
    if (meeting != null) 
    {
        // Use the meeting
    }
    else
    {
        // The first meeting was selected, or there are no meetings
    }
