    public class MeetingTime 
    {
      DateTime Start { get; set; }
      DateTime End { get; set; }
      List<Response> Responses { get; set; }
      public int NumAttendees 
      {        
        get { return Responses.Select(x => x.AttendeeId).Distinct().Count(); }
      }
      public MeetingTime(Response response) 
      {
        Start = response.StartDateTime;
        End = response.EndDateTime;
        Responses = new List<Response>();
      }
      public void MergeMeetingTime(Response response) 
      {
        // if response times are within current times, can be merged
        if (Start <= response.StartDateTime && response.EndDateTime <= End)
        {
           Start = response.StartDateTime;
           End = response.EndDateTime;
           Responses.Add(response);
        }
      }
    }
    public List<MeetingTime> FindMeetingTimes() 
    {
      var attendees = GetAttendees();
      var times = new List<MeetingTime> 
      bool isFirstAttendee = true;
      foreach (Attendee attendee in attendees) 
      {
        if (isFirstAttendee) 
        {
          foreach (Response response in attendee.Responses)
          {
            times.Add(new MeetingTime(response));
          }
          isFirstAttendee = false;
        } 
        else 
        {
          // Go through attendee.Responses and compare each with the current times
          // for each one, if it overlaps with a MeetingTime, then adjust 
          // the Start/End dates accordingly and increment Count
          // Uses same approach as above.          
          foreach (Response response in attendee.Responses)
          {
            times.ForEach(x => x.MergeMeetingTime(response));
          }
        }
      }
      // Remove all times where not everyone can attend
      times.Remove(x => x.NumAttendees < attendees.Count()).ToList();
      return times;
    }
