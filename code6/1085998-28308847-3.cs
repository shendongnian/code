        result = from i in _dbContext.Meetings
                 where i.UserInvitedID == CurrentUserID && i.MeetingStatus == null && //!i.IsTex &&
                 DbFunctions.AddMinutes(DbFunctions.AddHours(i.MeetingTime.Day, i.MeetingTime.Hour).Value, i.MeetingTime.Minute).Value > dateWithTime
                 //where i.UserInvitedID == CurrentUserID && i.MeetingStatus == null && DbFunctions.TruncateTime(i.AllowedTime.AllowedDate.Day) >= date
                 select MethodName(i);
