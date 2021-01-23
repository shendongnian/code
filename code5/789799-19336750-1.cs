    object obj = eventHelper.GetEventsForAdmin();
    var events = CastByExample(obj, new[] { 
                                        new { EventId = 0, 
                                              EventTitle = "",
                                              StartDateTime = DateTime.MinValue,
                                              Description = "", 
                                              CatTitle = ""
                                            }
                                          }.ToList());
    foreach (var item in events)
    {
        Console.WriteLine(item.EventId);
    }
    private static T CastByExample<T>(object obj, T example)
    {
        return (T)obj;
    }
