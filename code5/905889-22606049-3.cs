    IList<UserProfile> users = // Load user profile from database
    foreach(UserProfile user in user){
        // Work out this users local time by converting UTC to their local TimeZone
        DateTime localDateTime = Converter.ToLocalTime(DateTime.UtcNow, user.TimeZoneId);
        if(user.LastSent.HasValue && user.LastSent.Value.Date == localDateTime.Date){
           // Already sent an email today
           continue;
        }
        if(localDateTime.Hour >= 11 && localDateTime.Minute >= 30){
           // After 11:30am so send email (this could be much later than 11:30 depending on other factors)
           if(SendEmail(user.EmailId)){
               // Update last sent that must be in local time
               user.LastSent = Converter.ToLocalTime(DateTime.UtcNow, user.TimeZoneId);
               // Save User entity
               // UserPersistence.Save(user);
           }
        }
    }
