    foreach (KeyValuePair<DateTime?, Klassenbibliothek.TagNeu> Element in KalenderJahr) {
        Dictionary<string, object> calEvent = new Dictionary<string, object>();
        new SaveAppointmentTask {
    	    StartTime = Element.Value.Starttime,
    	    EndTime = Element.Value.Endtime,
    	    Subject = Element.Value.Name,
    	    Location = "",
    	    Details = "",
    	    IsAllDayEvent = ""
        }.Show();
    }
