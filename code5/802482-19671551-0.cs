    public static void LoadMeeting(this Agenda agenda, IMeetingRepository meetingRepository) 
    {
        if (agenda != null)
        {
             agenda.Meeting = meetingRepository.GetMeetingById(agenda.MeetingId);
        }
    }
    public static void LoadMeeting(this Participant participant, IMeetingRepository meetingRepository) 
    {
        if (participant != null)
        {
            participant.Meeting = meetingRepository.GetMeetingById(participant.MeetingId);
        }
    }
