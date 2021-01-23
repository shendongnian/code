                if (entity != null)
                {
                    entity.Meeting = meetingRepository.GetMeetingById(entity.MeetingId);
                }
            }
