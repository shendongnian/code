				var reminderValues = new ContentValues();
				reminderValues.Put(CalendarContract.Reminders.InterfaceConsts.EventId, eventID);
				reminderValues.Put(CalendarContract.Reminders.InterfaceConsts.Method, (int)RemindersMethod.Alert);
				reminderValues.Put(CalendarContract.Reminders.InterfaceConsts.Minutes, 5);
					}
			
