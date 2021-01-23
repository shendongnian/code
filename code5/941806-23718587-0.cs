    public static void addEvent(string eventDate, string eventTitle, string eventInfo)
        {
            Event Event = new Event();
            Event.eventDate = eventDate;
            Event.eventDate = eventTitle;
            Event.eventInfo = eventInfo;
            events.Add(Event);
            var bindinglist = new BindingList<Event>(events);
            var source = new BindingSource(bindingList, null);
            grid.DataSource = source;
          
        }
