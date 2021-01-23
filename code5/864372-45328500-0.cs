    UserCredential credential;
    using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
    {
        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            new[] { CalendarService.Scope.Calendar },
            "user", CancellationToken.None, new FileDataStore("Calendar.Sample.Store"));
    }
    
    // Create the service.
    var service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Calendar API Sample",
        });
    
    // Create a batch request.
    var request = new BatchRequest(service);
    request.Queue<CalendarList>(service.CalendarList.List(),
         (content, error, i, message) =>
         {
             // Put your callback code here.
         });
    request.Queue<Event>(service.Events.Insert(
         new Event
         {
             Summary = "Learn how to execute a batch request",
             Start = new EventDateTime() { DateTime = new DateTime(2014, 1, 1, 10, 0, 0) },
             End = new EventDateTime() { DateTime = new DateTime(2014, 1, 1, 12, 0, 0) }
         }, "YOUR_CALENDAR_ID_HERE"),
         (content, error, i, message) =>
         {
             // Put your callback code here.
         });
    // You can add more Queue calls here.
    
    // Execute the batch request, which includes the 2 requests above.
    await request.ExecuteAsync();
