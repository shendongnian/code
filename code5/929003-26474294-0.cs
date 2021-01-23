    Event myEvent = new Event
    {
      Summary = "Appointment",
      Location = "Somewhere",
      Start = new EventDateTime() {
          DateTime = new DateTime(2014, 6, 2, 10, 0, 0),
          TimeZone = "America/Los_Angeles"
      },
      End = new EventDateTime() {
          DateTime = new DateTime(2014, 6, 2, 10, 30, 0),
          TimeZone = "America/Los_Angeles"
      },
      Recurrence = new String[] {
          "RRULE:FREQ=WEEKLY;BYDAY=MO"
      },
      Attendees = new List<EventAttendee>()
          {
            new EventAttendee() { Email = "johndoe@gmail.com" }
          }
    };
    Event recurringEvent = service.Events.Insert(myEvent, "primary").Execute();
