    Expression<Func<Meeting, ITW2012Mobile.Core.DataTable.MeetingModel2Tmp>> projection = i =>
        new ITW2012Mobile.Core.DataTable.MeetingModel2Tmp()
        {
            Name = i.UserInviter.FirstName + " " + i.UserInviter.LastName,
            Company = i.UserInviter.Company,
            Company2 = i.UserInvited.Company,
            MeetingID = i.MeetingID,
            Time = DbFunctions.AddMinutes(DbFunctions.AddHours(i.MeetingTime.Day, i.MeetingTime.Hour).Value, i.MeetingTime.Minute).Value,
            CreatedTime = i.dateCreated,
            Image = i.UserInviter.ProfileImage,
            TableNumber = i.TableNumber,
            Username = i.UserInviter.aspnet_User.UserName,
            Username2 = i.UserInvited.aspnet_User.UserName,
            UsernameInviter = i.UserInviter.aspnet_User.UserName,
            RequestText = i.RequestText,
            NoteInviter = i.NoteInviter,
            ResendInvitationCount = (i.ResendInvitationCount.HasValue) ? i.ResendInvitationCount.Value : 0,
            NoteInvited = i.NoteInvited,
            MeetingType = i.MeetingType.TypeName
        };
    ...
    result =
       (from i in _dbContext.Meetings
        where i.UserInviterID == CurrentUserID
        && i.MeetingStatus == null
        && !i.IsTex
        && DbFunctions.AddMinutes(DbFunctions.AddHours(i.MeetingTime.Day, i.MeetingTime.Hour).Value, i.MeetingTime.Minute).Value > dateWithTime
        select i).Select(projection);
