            EventHandlerList events = (EventHandlerList)typeof(Component)
                   .GetField("events", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                   .GetValue(this);
            object current = events.GetType()
                   .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)[0]
                   .GetValue(events);
            List<Delegate> delegates = new List<Delegate>();
            while(current != null)
            {
                delegates.Add((Delegate)GetField(current,"handler"));
                current = GetField(current,"next");
            }
