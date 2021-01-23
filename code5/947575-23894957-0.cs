    string topic = Request.QueryString["topic"];
    string date = Request.QueryString["date"];
    string keyword = Request.QueryString["keyword"];
    
    var filteredItems = root.Children()
                            .Where(x => x.IsDocumentType("Event-Item"));
    if (!string.IsNullOrEmpty(topic))
        filteredItems = filteredItems.Where(x => x.GetPropertyValue("eventTitle")
                                                  .ToString()
                                                  .Contains(topic));
    if (!string.IsNullOrEmpty(date))
        filteredItems = filteredItems.Where(x => x.GetPropertyValue("eventDates")
                                                  .ToString()
                                                  .Contains(date));
    if (!string.IsNullOrEmpty(keyword))
        filteredItems = filteredItems.Where(x => x.GetPropertyValue("eventSummary")
                                                  .ToString()
                                                  .Contains(keyword));
    items = filteredItems.OrderByDescending(x => x.CreateDate).ToList();
