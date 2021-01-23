    var obj = new ReturnResponse
              {
                  result = "1",
                  sessionId = "123213214214",
                  eventList = new Event() 
                              {
                                  eventIDs = getEventsInfo["listEventID"],
                                  eventNames = getEventsInfo["listEventName"]
                              }
              };
    var json = new JavaScriptSerializer().Serialize(obj);
    Response.Write(json);    
