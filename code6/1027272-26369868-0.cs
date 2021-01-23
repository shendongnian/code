            EventHandlerList events = (EventHandlerList)typeof(Component)
                   .GetField("events", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                   .GetValue(this);
            var listItem = events.GetType()
                   .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)[0]
                   .GetValue(events);
            List<Delegate> delegates = new List<Delegate>();
            object current = listItem;
            while(true)
            {
                if (current == null)
                    break;
                delegates.Add(GetDelegate(current));
                current = GetNext(current);
            }
