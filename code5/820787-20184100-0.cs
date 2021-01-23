    // I'm not a fan of the Dto suffix, but it makes this example easier
    public class UserNotificationDto 
    {
        // the properties you want to expose through WCF 
        public Guid UserGuid { get; set; }
        public string Message { get; set; }
        // ...        
    }
    // your service method
    IEnumerable<UserNotificationDto> GetNotifications(Guid userGuid)
    {
        using (var ctx = new Context())
        {
            return ctx.User_Notifications
                .Where(x => !x.IsDismissed && x.UserGuid == userGuid)
                .Select(
                    x => new UserNotificationDto { 
                        UserGuid = x.UserGuid, 
                        Message = x.Message 
                    }
                ).ToList();
        }
    }
