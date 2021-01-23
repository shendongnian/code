    public static void LoadMeeting<T>(this T entity, IMeetingRepository meetingRepository) where T: MyEntity
            {
                var agenda = entity as Agenda;
                if (agenda != null)
                {
                    agenda.Meeting = meetingRepository.GetMeetingById(agenda.MeetingId);
                    return;
                }
                var participant = entity as Participant;
                if (participant != null)
                {
                    participant.Meeting = meetingRepository.GetMeetingById(participant.MeetingId);
                    return;
                }
            }
