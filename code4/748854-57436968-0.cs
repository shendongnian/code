cs
[Route("SesNotification")]
[HttpPost]
public async Task<IActionResult> SesNotificationAsync()
{
    var body = string.Empty;
    using (var reader = new StreamReader(Request.Body))
    {
        body = await reader.ReadToEndAsync();
    }
    
    var notificationProcessor = new NotificationProcessor();
    var result = await notificationProcessor.ProcessNotificationAsync(body);
    
    //Your processing logic...
    
    return StatusCode(StatusCodes.Status200OK);
}
