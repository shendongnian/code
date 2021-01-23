    theList.Sort(delegate(Event p1, Event p2)
                 {
                       var byStart = p1.Start.CompareTo(p2.Start);
                       var byEnd = p1.End.CompareTo(p2.End);
                       var byEventName = p1.EventName.CompareTo(p2.EventName);
                       return byStart == 0 ? byEnd == 0 ? byEventName : byEnd : byStart;
                 });
