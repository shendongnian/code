    public class Attendee
    {
        public ICollection<Response> Responses { get; set; } 
    }
    
    public class Response
    {
    	public DateTime StartDateTime { get; set; }
    	public DateTime EndDateTime { get; set; }
    }
    
    public class Window
    {
    	public DateTime StartDateTime { get; set; }
    	public DateTime EndDateTime { get; set; }
    	public IEnumerable<Attendee> AvailableAttendees { get; set; }	
    }
    
    public IEnumerable<Window> GetMeetingWindows(IEnumerable<Attendee> attendees, TimeSpan meetingDuration)
    {
    	var windows = new List<Window>();
    	var responses = attendees.SelectMany(x => x.Responses).Where(x => x.EndDateTime - x.StartDateTime >= meetingDuration);
    	
    	foreach(var time in (responses.Select(x => x.StartDateTime)).Distinct())
    	{
    		var matches = attendees.Select(x => new { 
    			Attendee = x, 
    			MatchingAvailabilities = x.Responses.Where(y => y.StartDateTime <= time && y.EndDateTime >= time.Add(meetingDuration)) 
    		});
    		
    		windows.Add(new Window { 
    			StartDateTime = time, 
    			EndDateTime = matches.SelectMany(x => x.MatchingAvailabilities).Min(x => x.EndDateTime), 
    			AvailableAttendees = matches.Where(y => y.MatchingAvailabilities.Any()).Select(x => x.Attendee) 
    		});
    	}
    
    	foreach(var time in (responses.Select(x => x.EndDateTime)).Distinct())
    	{
    		var matches = attendees.Select(x => new { 
    			Attendee = x, 
    			MatchingAvailabilities = x.Responses.Where(y => y.EndDateTime >= time && y.StartDateTime <= time.Add(-meetingDuration)) 
    		});
    		
    		windows.Add(new Window { 
    			EndDateTime = time, 
    			StartDateTime = matches.SelectMany(x => x.MatchingAvailabilities).Max(x => x.StartDateTime), 
    			AvailableAttendees = matches.Where(y => y.MatchingAvailabilities.Any()).Select(x => x.Attendee) 
    		});
    	}
    	
    	return windows.GroupBy(x => new { x.StartDateTime, x.EndDateTime }).Select(x => x.First()).OrderBy(x => x.StartDateTime).ThenBy(x => x.EndDateTime);
    }
    
    public void Test() 
    {
    	var attendees = new List<Attendee>();
    	attendees.Add(new Attendee { Responses = new[] { 
    		new Response { StartDateTime = DateTime.Parse("2014-02-24 9:00:00 AM"), EndDateTime = DateTime.Parse("2014-02-24 11:00:00 AM") },
    		new Response { StartDateTime = DateTime.Parse("2014-02-24 2:00:00 PM"), EndDateTime = DateTime.Parse("2014-02-24 4:00:00 PM") },
    		new Response { StartDateTime = DateTime.Parse("2014-02-25 9:00:00 AM"), EndDateTime = DateTime.Parse("2014-02-25 11:00:00 AM") },
    		new Response { StartDateTime = DateTime.Parse("2014-02-25 3:00:00 PM"), EndDateTime = DateTime.Parse("2014-02-25 5:00:00 PM") }
    	}});
    	attendees.Add(new Attendee { Responses = new[] { 
    		new Response { StartDateTime = DateTime.Parse("2014-02-24 10:00:00 AM"), EndDateTime = DateTime.Parse("2014-02-24 11:00:00 AM") },
    		new Response { StartDateTime = DateTime.Parse("2014-02-24 4:00:00 PM"), EndDateTime = DateTime.Parse("2014-02-24 5:00:00 PM") },
    		new Response { StartDateTime = DateTime.Parse("2014-02-25 9:00:00 AM"), EndDateTime = DateTime.Parse("2014-02-25 11:00:00 AM") }
    	}});
    
    	var windows = GetMeetingWindows(attendees, TimeSpan.FromMinutes(60));
    	foreach(var window in windows)
    	{
    		Console.WriteLine(String.Format("Start: {0:yyyy-MM-dd HH:mm}, End: {1:yyyy-MM-dd HH:mm}, AttendeeCount: {2}", window.StartDateTime, window.EndDateTime, window.AvailableAttendees.Count()));
    	}
    }
