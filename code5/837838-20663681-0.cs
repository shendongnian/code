    logMock.AssertWasCalled(
      call => call.Save(
        Arg<Website.CodeModules.BusinessObjects.Audit.ActivityLog>.Matches(
          logItem => logItem.UserID == user.GuidID && logItem.Type == Enums.ActivityType.Login
        )
      )
    );
