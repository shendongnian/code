			[NonEvent]
			public void Warning(int tracerId, string message, params object[] args)
			{
				if (args != null)
					message = string.Format(message, args);
				Warning(tracerId, message);
			}
			[Event(EventIds.Warning, Level = EventLevel.Warning)]
			public void Warning(int tracerId, string message)
			{
				WriteEvent(EventIds.Warning, tracerId, message); 
			}
