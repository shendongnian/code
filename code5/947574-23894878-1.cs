        var topic = Request.QueryString["topic"];
        var date = Request.QueryString["date"];
        var keyword = Request.QueryString["keyword"];
        
        items = root
                  .Children()
                  .Where(x => x.IsDocumentType("Event-Item"));
        
        if (!string.IsNullOrEmpty(topic) || !string.IsNullOrEmpty(date) || !string.IsNullOrEmpty(keyword))
        {
            items = items.Where(x =>                    
                x.GetPropertyValue("eventTitle").ToString().Contains(topic) || 
                x.GetPropertyValue("eventDates").ToString().Contains(date) || 
                x.GetPropertyValue("eventSummary").ToString().Contains(keyword));
        }
    
        items = items.OrderByDescending(x => x.CreateDate);
