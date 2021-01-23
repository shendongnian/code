    public class MeetingTime {
      DateTime Start { get; set; }
      DateTime End { get; set; }
      int Count { get; set; }
    }
    public List<MeetingTime> FindMeetingTimes() {
      var attendees = GetAttendees();
      var times = new List<MeetingTime> 
      bool isFirstAttendee = true;
      foreach (Attendee attendee in attendees) 
      {
        if (isFirstAttendee) 
        {
          foreach (Response response in attendee.Responses) {
            times.Add(new MeetingTime { 
                             Start = response.StartDateTime, 
                             End = response.EndDateTime},
                             Count = 1
                      );
          }
          isFirstAttendee = false;
        } 
        else 
        {
          // Go through attendee.Responses and compare each with the current times
          // for each one, if it overlaps with a MeetingTime, then adjust 
          // the Start/End dates accordingly and increment Count
          // Uses same approach as above.
        }
      }
      // Remove all times where not everyone can attend
      times.Remove(x => x.Count < attendees.Count()).ToList();
      return times;
    }
