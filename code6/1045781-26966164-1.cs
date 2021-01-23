    var obj = new ReturnResponse
              {
                result = "1",
                sessionId = "123213214214",
                eventList = new EventList() 
                            {  
                              eventIDs = getEventsInfo["listEventID"],
                              eventNames =  getEventsInfo["listEventName"]
                            }
              }; 
